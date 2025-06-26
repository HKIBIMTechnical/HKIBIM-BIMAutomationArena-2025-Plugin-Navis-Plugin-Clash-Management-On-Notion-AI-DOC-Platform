using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.DocumentParts;
using Autodesk.Navisworks.Api.Plugins;
using Microsoft.VisualBasic;
using EXCEL = Microsoft.Office.Interop.Excel;
using NavisDemo;



namespace Notion
{
    public partial class Notion_Form : Form
    {
        public static Document doc = null;
        public static FolderItem rootfolderitem=null;
        public static List<SavedItem> silist;
        public static List<SavedItem> checkedSavedItemList;
        public static ModelItemCollection RecordSelection;
        public static bool boolVPArrowByChecked = false;
        public static bool boolVPArrowBySelected = false;
        public static bool boolMultiSelectOnlyHighLight = false;

        public static SavedItem selectedNodeSavedItem;
        public static double ArrowSize = 304.8;
        public static TreeView treeView;
        public static List<TreeNode> HighlightNodeList;
        public static List<SavedItem> HighlightNodeSavedItemList;
        public static List<TreeNode> alltreenodes;
         
        public Notion_Form()
        { 
            InitializeComponent();
            doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
            rootfolderitem = navisFun2019.GetRootFolderItem(doc);
            treeView = treeViewViewpointTree;

        }

        private void buttonLoadVP_Click(object sender, EventArgs e)
        {
            try
            {
                doc = Autodesk.Navisworks.Api.Application.ActiveDocument;
                silist = navisFun2019.GetAllViewpointAndFolderItemUnderOneFolderItem(rootfolderitem);

                 
                for (int i = silist.Count - 1; i >= 0; i--)
                {
                    navisFun2019.set_new_GUID_to_VPorVPFolder(doc, silist[i]);
                }
                silist = navisFun2019.GetAllViewpointAndFolderItemUnderOneFolderItem(rootfolderitem);

                treeViewViewpointTree.Nodes.Clear();
                foreach (SavedItem item in silist)
                {
                    TreeNode[] findNodes = treeViewViewpointTree.Nodes.Find(item.Parent.Guid.ToString(), true);
                    TreeNode parentNode;
                    TreeNode tn;
                    if (findNodes.Count() > 0)
                    {
                        parentNode = findNodes.First();
                        tn = parentNode.Nodes.Add(item.DisplayName);
                        tn.Name = item.Guid.ToString();
                    }
                    else
                    {
                        tn = treeViewViewpointTree.Nodes.Add(item.DisplayName);
                        tn.Name = item.Guid.ToString();
                    }
                }

                if (doc.SavedViewpoints.CurrentSavedViewpoint != null)
                {
                    treeViewViewpointTree.SelectedNode =
                        treeViewViewpointTree.Nodes.
                        Find(doc.SavedViewpoints.CurrentSavedViewpoint.Guid.ToString(), true).First();
                }

                alltreenodes = navisFun2019.GetAllTreeNode(treeViewViewpointTree.Nodes);


            }
            catch (Exception)
            {
            }



        }

        private void treeViewViewpointTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Nodes.Count > 0)
                {
                    bool NoFalse = true;
                    foreach (TreeNode tn in e.Node.Nodes)
                    {
                        if (tn.Checked == false)
                        {
                            NoFalse = false;
                        }
                    }
                    if (e.Node.Checked == true || NoFalse)
                    {
                        foreach (TreeNode tn in e.Node.Nodes)
                        {
                            if (tn.Checked != e.Node.Checked)
                            {
                                tn.Checked = e.Node.Checked;
                            }
                        }
                    }
                }
                if (e.Node.Parent != null && e.Node.Parent is TreeNode)
                {
                    bool ParentNode = true;
                    foreach (TreeNode tn in e.Node.Parent.Nodes)
                    {
                        if (tn.Checked == false)
                        {
                            ParentNode = false;
                        }
                    }
                    if (e.Node.Parent.Checked != ParentNode && (e.Node.Checked == false || e.Node.Checked == true && e.Node.Parent.Checked == false))
                    {
                        e.Node.Parent.Checked = ParentNode;
                    }
                }


                Viewpoint curVP = doc.CurrentViewpoint;
                Viewpoint copyVP = curVP.CreateCopy();
                Point3D position = copyVP.Position;
                Point3D newposition = new Point3D(position.X, position.Y, position.Z + 0.000000001);
                copyVP.Position = newposition;

                doc.CurrentViewpoint.CopyFrom(copyVP);
            }
            catch (Exception)
            {
            }


        }

        private void treeViewViewpointTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                SavedItem si = silist.Where(x => x.Guid.ToString() == treeViewViewpointTree.SelectedNode.Name).First();
                selectedNodeSavedItem = si;
                if (si.IsGroup == false)
                {
                    string tempstr = "viewpoint name: " + si.DisplayName + "\r\n" + navisFun2019.GetSavedItemCommentsString(si);
                }
                else
                {
                    string tempstr = "vp folder name: " + si.DisplayName + "\r\n" + navisFun2019.GetSavedItemCommentsString(si);
                }

                Viewpoint curVP = doc.CurrentViewpoint;
                Viewpoint copyVP = curVP.CreateCopy();
                Point3D position = copyVP.Position;
                Point3D newposition = new Point3D(position.X, position.Y, position.Z + 0.00000000001);
                copyVP.Position = newposition;

                doc.CurrentViewpoint.CopyFrom(copyVP);



            }
            catch (Exception)
            {
            }
        }

        private TreeNode lastSelectedNode;
        private void treeViewViewpointTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    e.Cancel = true;
                    if (lastSelectedNode != null)
                    {
                        var startNode = lastSelectedNode;
                        var endNode = e.Node;
                        if (startNode == endNode) return;
                        if (startNode.Parent != endNode.Parent) return;
                        var isUp = startNode.Index > endNode.Index;
                        var start = isUp ? endNode.Index : startNode.Index;
                        var end = isUp ? startNode.Index : endNode.Index;
                        var nodes = startNode.Parent.Nodes.Cast<TreeNode>().Skip(start).Take(end - start + 1);

                        treeViewViewpointTree.BeginUpdate();
                        foreach (var node in nodes)
                        {
                            if (checkBoxMultiSelectOnlyHighlight.Checked == false)
                            {
                                if (node.Checked == true)
                                {
                                    node.Checked = false;
                                }
                                else
                                {
                                    node.Checked = true;
                                }
                            }
                            else
                            {
                                node.BackColor = SystemColors.Highlight;
                                node.ForeColor = SystemColors.HighlightText;
                            }
                        }
                        treeViewViewpointTree.EndUpdate();
                    }
                }
                else
                {
                    lastSelectedNode = e.Node;
                }
                HighlightNodeList = alltreenodes.Where(x => x.BackColor == SystemColors.Highlight).ToList();

            }
            catch (Exception)
            {

            }

        }

        private void treeViewViewpointTree_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                silist = navisFun2019.GetAllViewpointAndFolderItemUnderOneFolderItem(doc.SavedViewpoints.RootItem);
                if (e.KeyCode == Keys.Delete)
                {
                    SavedItem si = silist.Where(x => x.Guid.ToString() == treeViewViewpointTree.SelectedNode.Name).First();
                    //silist.Remove(si);
                    doc.SavedViewpoints.Remove(si.Parent, si);
                    treeViewViewpointTree.SelectedNode.Remove();
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (treeViewViewpointTree.SelectedNode.Nodes.Count == 0)
                    {
                        if (treeViewViewpointTree.SelectedNode != null)
                        {
                            SavedItem si = silist.Where(x => x.Guid.ToString() == treeViewViewpointTree.SelectedNode.Name).First();
                            if (si.IsGroup == false)
                            {
                                doc.SavedViewpoints.CurrentSavedViewpoint = si;
                            }
                            this.Activate();
                        }
                    }
                }
                if (e.KeyCode == Keys.Space)
                {
                    if (treeViewViewpointTree.SelectedNode.Checked == true)
                    {
                        treeViewViewpointTree.SelectedNode.Checked = false;
                    }
                    else
                    {
                        treeViewViewpointTree.SelectedNode.Checked = true;
                    }
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }


        }

        private void treeViewViewpointTree_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    TreeNode selectedNode = treeViewViewpointTree.GetNodeAt(e.X, e.Y);
                    if (selectedNode != null) // && !selectedNodes.Contains(selectedNode))
                    {
                        if (checkBoxMultiSelectOnlyHighlight.Checked == false)
                        {
                            if (selectedNode.Checked == true)
                            {
                                selectedNode.Checked = false;
                            }
                            else
                            {
                                selectedNode.Checked = true;
                            }
                        }
                        else
                        {
                            selectedNode.BackColor = SystemColors.Highlight;
                            selectedNode.ForeColor = SystemColors.HighlightText;
                        }
                    }


                }

                HighlightNodeList = alltreenodes.Where(x => x.BackColor == SystemColors.Highlight).ToList();

            }
            catch (Exception)
            {
            }
        }

        private void treeViewViewpointTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (treeViewViewpointTree.SelectedNode != null)
                {
                    SavedItem si = silist.Where(x => x.Guid.ToString() == treeViewViewpointTree.SelectedNode.Name).First();
                    if (si.IsGroup == false)
                    {
                        doc.SavedViewpoints.CurrentSavedViewpoint = si;
                    }
                }
            }
            catch (Exception)
            {
            } 
        }

        private void btnToNotion_Click(object sender, EventArgs e)
        {
            try   
            { 
                alltreenodes = navisFun2019.GetAllTreeNode(treeViewViewpointTree.Nodes);
                List<TreeNode> checkedVPnode = alltreenodes.Where(x => x.Nodes.Count == 0).Where(x => x.Checked == true).ToList();
                List<SavedItem> checkedVPlist = silist.Where(x => x.IsGroup == false).
                    Where(x => checkedVPnode.Select(y => y.Name).Contains(x.Guid.ToString())).ToList();


                foreach (var checkedVP in checkedVPlist)
                {
                    doc.SavedViewpoints.CurrentSavedViewpoint = checkedVP;
                    string vp_id = checkedVP.Guid.ToString();
                    string vp_name = checkedVP.DisplayName;
                    string status = vp_name.ToLower().Contains("close") ? "Close" : "In_Progress";
                    string comments =
                        navisFun2019.GetSavedItemCommentsString(checkedVP) == "" ||
                        navisFun2019.GetSavedItemCommentsString(checkedVP) == null ? " " : navisFun2019.GetSavedItemCommentsString(checkedVP);//.Replace("\n",""); //20241216 
                    string path = navisFun2019.GetViewpointOrFolderItemPath(checkedVP);
                    string s_date = systemFun.getCurrentDate();
                    string e_date = vp_name.ToLower().Contains("close") ? systemFun.getCurrentDate():" ";
                    string export_folder_path = @"C:\export_temp";
                    string imagePath = System.IO.Path.Combine(export_folder_path, systemFun.getCurrentDate()+systemFun.getCurrentTime() + "_" + vp_name + ".png");

                    if (checkBoxUploadVPImageToNotion.Checked)
                    {
                        navisFun2019.imageGenerate(export_folder_path, systemFun.getCurrentDate() + systemFun.getCurrentTime() + "_" + vp_name);
                    }





                    string tempstr =
                        vp_id + "++++++++++++++" +
                        vp_name + "++++++++++++++" +
                        comments + "++++++++++++++" +
                        path + "++++++++++++++" +
                        s_date + "++++++++++++++" +
                        e_date + "++++++++++++++" +
                        imagePath + "++++++++++++++" +
                        textBoxDataTableId.Text
                        ;
                    using (StreamWriter outputfile=new StreamWriter(Path.Combine(export_folder_path,"temp_python_input_parameter.txt")))
                    {
                        outputfile.WriteLine(tempstr);


                    }






                    string pypath = @"\Notion\notionFun.py";
                    string pyNoImagePath = @"\Notion\notionFun_No_Image.py";
                    if (checkBoxUploadVPImageToNotion.Checked)
                    {
                        if (System.IO.File.Exists(pypath))
                        {
                            Process p = new Process();
                            p.StartInfo = new ProcessStartInfo(@"C:\Users\Administrator\AppData\Local\Programs\Python\Python39\python.exe", pypath)
                            {
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                CreateNoWindow = true,
                                //                             RedirectStandardError = true                           
                                 
                            };
                            p.Start();
                            string output = p.StandardOutput.ReadToEnd();
                            p.WaitForExit();
//                             MessageBox.Show(output);

                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(pyNoImagePath))
                        {
                            Process p = new Process();
                            p.StartInfo = new ProcessStartInfo(@"C:\Users\Administrator\AppData\Local\Programs\Python\Python39\python.exe", pyNoImagePath)
                            {
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                CreateNoWindow = true,
                                //                             RedirectStandardError = true                           

                            };
                            p.Start();
                            string output = p.StandardOutput.ReadToEnd();
                            p.WaitForExit();
                            //MessageBox.Show(output);

                        }

                    }









                }

                MessageBox.Show("finish");
            }
            catch (Exception)
            {
                MessageBox.Show("exist error");
            }



        }

        private void btnFindVPTreeNode_Click(object sender, EventArgs e)
        {
            doc = Autodesk.Navisworks.Api.Application.ActiveDocument;

            if (textBoxFindVPByContainText.Text!="")
            {
                rootfolderitem = navisFun2019.GetRootFolderItem(doc);
                silist = navisFun2019.GetAllViewpointAndFolderItemUnderOneFolderItem(rootfolderitem);
                string textstring = textBoxFindVPByContainText.Text.Replace("\n", "").Replace("\r", "").Replace("\r\n","");
                if (silist.Where(x=>x.DisplayName.Contains(textstring)).Count()>0)
                {
                    treeViewViewpointTree.SelectedNode =
                        treeViewViewpointTree.Nodes.
                        Find(silist.Where(x => x.DisplayName.Contains(textstring)).First().Guid.ToString(), true).First();
                }
                treeViewViewpointTree.Focus();

            }
        }
    }
}
