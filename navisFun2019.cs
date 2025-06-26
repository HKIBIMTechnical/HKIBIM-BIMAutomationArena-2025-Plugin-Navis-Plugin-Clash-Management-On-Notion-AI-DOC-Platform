using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using NavisworksIntegratedAPI22;

namespace Notion
{
    class navisFun201911
    {
        public static List<SavedItem> GetAllViewpointAndFolderItemUnderOneFolderItem(SavedItem fi)
        {
            List<SavedItem> silist = new List<SavedItem>();
            if (fi.IsGroup)
            {
                foreach (SavedItem item in (fi as FolderItem).Children)
                {
                    silist.Add(item);
                    if (item.IsGroup)
                    {
                        GetAllViewpointAndFolderItemUnderOneFolderItem(item);
                        silist.AddRange(GetAllViewpointAndFolderItemUnderOneFolderItem(item));
                    }
                }
            }
            return silist;
        }
        public static void set_new_GUID_to_VPorVPFolder(Document doc, SavedItem si)
        {
            if (si.Guid.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                SavedItem tempsi = si.CreateCopy();
                Guid guid = Guid.NewGuid();
                tempsi.Guid = guid;
                doc.SavedViewpoints.ReplaceWithCopy(si.Parent, si.Parent.Children.IndexOf(si), tempsi);
            }
        }
        public static List<TreeNode> GetAllTreeNode(TreeNodeCollection treeNodeCollection)
        {
            List<TreeNode> nodelist = new List<TreeNode>();
            foreach (TreeNode item in treeNodeCollection)
            {
                nodelist.Add(item);
                if (item.Nodes.Count > 0)
                {
                    GetAllTreeNode(item.Nodes);
                    nodelist.AddRange(GetAllTreeNode(item.Nodes));
                }
            }
            return nodelist;
        }
        public static string GetSavedItemCommentsString(SavedItem si)
        {
            CommentCollection commentcollection = si.Comments;
            string commentstring = null;
            foreach (Comment c in commentcollection)
            {
                commentstring += c.Body + "\n";
            }

            return commentstring;
        }
        public static FolderItem GetRootFolderItem(Autodesk.Navisworks.Api.Document doc)
        {
            DocumentSavedViewpoints dsvs = doc.SavedViewpoints;
            return dsvs.RootItem;
        }
        public static string GetViewpointOrFolderItemPath(SavedItem si)
        {
            List<string> strlist = new List<string>();
            while (si != null)
            {
                strlist.Add(si.DisplayName);
                si = si.Parent;
            }
            strlist.RemoveAt(strlist.Count - 1);
            strlist.Reverse();
            string tempstr = "";
            foreach (string item in strlist)
            {
                tempstr += item + "|||";
            }
            return tempstr;
        }
        public static void imageGenerate(string imageSavePath, string imageNameWithoutExtension)//, double height = 550, double width = 1040)
        {

            NavisworksAutomationAPI22.Document doc16 = System.Runtime.InteropServices.Marshal.GetActiveObject("navisworks.document.22") as NavisworksAutomationAPI22.Document;

            InwOpState10 oState = doc16.State();
            InwOaPropertyVec options = oState.GetIOPluginOptions("lcodpimage");

            foreach (InwOaProperty opt in
                    options.Properties())
            {
                if (opt.name == "export.image.format")
                    opt.value = "lcodpexpng";
                if (opt.name == "export.image.height")
                {
                    opt.value = 500;// (dynamic) height;
                }
                if (opt.name == "export.image.width")
                {
                    opt.value = 1050;// (dynamic)width;
                }
            }

            string snapshot = Path.Combine(imageSavePath, imageNameWithoutExtension + ".png");
            oState.DriveIOPlugin("lcodpimage", snapshot, options);


        }

    }


}
