
namespace Notion
{
    partial class Notion_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notion_Form));
            this.buttonLoadVP = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxUploadVPImageToNotion = new System.Windows.Forms.CheckBox();
            this.textBoxFindVPByContainText = new System.Windows.Forms.TextBox();
            this.btnFindVPTreeNode = new System.Windows.Forms.Button();
            this.btnToNotion = new System.Windows.Forms.Button();
            this.checkBoxMultiSelectOnlyHighlight = new System.Windows.Forms.CheckBox();
            this.treeViewViewpointTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDataTableId = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadVP
            // 
            this.buttonLoadVP.Location = new System.Drawing.Point(9, 36);
            this.buttonLoadVP.Name = "buttonLoadVP";
            this.buttonLoadVP.Size = new System.Drawing.Size(156, 65);
            this.buttonLoadVP.TabIndex = 0;
            this.buttonLoadVP.Text = "Load VP";
            this.buttonLoadVP.UseVisualStyleBackColor = true;
            this.buttonLoadVP.Click += new System.EventHandler(this.buttonLoadVP_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 403);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxUploadVPImageToNotion);
            this.tabPage1.Controls.Add(this.textBoxFindVPByContainText);
            this.tabPage1.Controls.Add(this.btnFindVPTreeNode);
            this.tabPage1.Controls.Add(this.btnToNotion);
            this.tabPage1.Controls.Add(this.checkBoxMultiSelectOnlyHighlight);
            this.tabPage1.Controls.Add(this.treeViewViewpointTree);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxDataTableId);
            this.tabPage1.Controls.Add(this.buttonLoadVP);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxUploadVPImageToNotion
            // 
            this.checkBoxUploadVPImageToNotion.AutoSize = true;
            this.checkBoxUploadVPImageToNotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUploadVPImageToNotion.ForeColor = System.Drawing.Color.Maroon;
            this.checkBoxUploadVPImageToNotion.Location = new System.Drawing.Point(9, 141);
            this.checkBoxUploadVPImageToNotion.Name = "checkBoxUploadVPImageToNotion";
            this.checkBoxUploadVPImageToNotion.Size = new System.Drawing.Size(173, 17);
            this.checkBoxUploadVPImageToNotion.TabIndex = 52;
            this.checkBoxUploadVPImageToNotion.Text = "upload vp image to notion";
            this.checkBoxUploadVPImageToNotion.UseVisualStyleBackColor = true;
            // 
            // textBoxFindVPByContainText
            // 
            this.textBoxFindVPByContainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFindVPByContainText.Location = new System.Drawing.Point(182, 298);
            this.textBoxFindVPByContainText.Multiline = true;
            this.textBoxFindVPByContainText.Name = "textBoxFindVPByContainText";
            this.textBoxFindVPByContainText.Size = new System.Drawing.Size(421, 53);
            this.textBoxFindVPByContainText.TabIndex = 51;
            // 
            // btnFindVPTreeNode
            // 
            this.btnFindVPTreeNode.Location = new System.Drawing.Point(9, 298);
            this.btnFindVPTreeNode.Name = "btnFindVPTreeNode";
            this.btnFindVPTreeNode.Size = new System.Drawing.Size(156, 53);
            this.btnFindVPTreeNode.TabIndex = 50;
            this.btnFindVPTreeNode.Text = "Find VP By Contain Text";
            this.btnFindVPTreeNode.UseVisualStyleBackColor = true;
            this.btnFindVPTreeNode.Click += new System.EventHandler(this.btnFindVPTreeNode_Click);
            // 
            // btnToNotion
            // 
            this.btnToNotion.Location = new System.Drawing.Point(9, 182);
            this.btnToNotion.Name = "btnToNotion";
            this.btnToNotion.Size = new System.Drawing.Size(156, 53);
            this.btnToNotion.TabIndex = 49;
            this.btnToNotion.Text = "To Notion";
            this.btnToNotion.UseVisualStyleBackColor = true;
            this.btnToNotion.Click += new System.EventHandler(this.btnToNotion_Click);
            // 
            // checkBoxMultiSelectOnlyHighlight
            // 
            this.checkBoxMultiSelectOnlyHighlight.AutoSize = true;
            this.checkBoxMultiSelectOnlyHighlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMultiSelectOnlyHighlight.ForeColor = System.Drawing.Color.Maroon;
            this.checkBoxMultiSelectOnlyHighlight.Location = new System.Drawing.Point(9, 118);
            this.checkBoxMultiSelectOnlyHighlight.Name = "checkBoxMultiSelectOnlyHighlight";
            this.checkBoxMultiSelectOnlyHighlight.Size = new System.Drawing.Size(167, 17);
            this.checkBoxMultiSelectOnlyHighlight.TabIndex = 48;
            this.checkBoxMultiSelectOnlyHighlight.Text = "multiSelect only highlight";
            this.checkBoxMultiSelectOnlyHighlight.UseVisualStyleBackColor = true;
            // 
            // treeViewViewpointTree
            // 
            this.treeViewViewpointTree.CheckBoxes = true;
            this.treeViewViewpointTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewViewpointTree.Location = new System.Drawing.Point(188, 36);
            this.treeViewViewpointTree.Name = "treeViewViewpointTree";
            this.treeViewViewpointTree.Size = new System.Drawing.Size(415, 251);
            this.treeViewViewpointTree.TabIndex = 3;
            this.treeViewViewpointTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewViewpointTree_AfterCheck);
            this.treeViewViewpointTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewViewpointTree_BeforeSelect);
            this.treeViewViewpointTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewViewpointTree_AfterSelect);
            this.treeViewViewpointTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewViewpointTree_NodeMouseDoubleClick);
            this.treeViewViewpointTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewViewpointTree_KeyDown);
            this.treeViewViewpointTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewViewpointTree_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DataTable Id";
            // 
            // textBoxDataTableId
            // 
            this.textBoxDataTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataTableId.Location = new System.Drawing.Point(81, 8);
            this.textBoxDataTableId.Name = "textBoxDataTableId";
            this.textBoxDataTableId.Size = new System.Drawing.Size(522, 22);
            this.textBoxDataTableId.TabIndex = 1;
            this.textBoxDataTableId.Text = "56730fb51a104596bab8a60d3c68622e";
            this.textBoxDataTableId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Notion_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 407);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Notion_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notion_Form";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadVP;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDataTableId;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeViewViewpointTree;
        private System.Windows.Forms.CheckBox checkBoxMultiSelectOnlyHighlight;
        private System.Windows.Forms.Button btnToNotion;
        private System.Windows.Forms.TextBox textBoxFindVPByContainText;
        private System.Windows.Forms.Button btnFindVPTreeNode;
        private System.Windows.Forms.CheckBox checkBoxUploadVPImageToNotion;
    }
}