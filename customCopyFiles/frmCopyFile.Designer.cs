namespace CopyFiles
{
    partial class frmCopyFile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCopyFiles = new System.Windows.Forms.Button();
            this.dgDir = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrcFolder = new System.Windows.Forms.TextBox();
            this.btnSrcFolder = new System.Windows.Forms.Button();
            this.btnDestFolder = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.txtFilterNames = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtMissedItems = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Location = new System.Drawing.Point(611, 389);
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.Size = new System.Drawing.Size(176, 39);
            this.btnCopyFiles.TabIndex = 0;
            this.btnCopyFiles.Text = "Copy Files";
            this.btnCopyFiles.UseVisualStyleBackColor = true;
            this.btnCopyFiles.Click += new System.EventHandler(this.btnCopyFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Folder:";
            // 
            // txtSrcFolder
            // 
            this.txtSrcFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcFolder.Location = new System.Drawing.Point(8, 45);
            this.txtSrcFolder.Multiline = true;
            this.txtSrcFolder.Name = "txtSrcFolder";
            this.txtSrcFolder.Size = new System.Drawing.Size(779, 75);
            this.txtSrcFolder.TabIndex = 2;
            this.txtSrcFolder.Text = "K:\\SourceFolder";
            // 
            // btnSrcFolder
            // 
            this.btnSrcFolder.Location = new System.Drawing.Point(121, 9);
            this.btnSrcFolder.Name = "btnSrcFolder";
            this.btnSrcFolder.Size = new System.Drawing.Size(201, 35);
            this.btnSrcFolder.TabIndex = 3;
            this.btnSrcFolder.Text = "Browse Source Folder";
            this.btnSrcFolder.UseVisualStyleBackColor = true;
            this.btnSrcFolder.Click += new System.EventHandler(this.btnSrcFolder_Click);
            // 
            // btnDestFolder
            // 
            this.btnDestFolder.Location = new System.Drawing.Point(152, 266);
            this.btnDestFolder.Name = "btnDestFolder";
            this.btnDestFolder.Size = new System.Drawing.Size(201, 35);
            this.btnDestFolder.TabIndex = 6;
            this.btnDestFolder.Text = "Browse Destination Folder";
            this.btnDestFolder.UseVisualStyleBackColor = true;
            this.btnDestFolder.Click += new System.EventHandler(this.btnDestFolder_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestFolder.Location = new System.Drawing.Point(8, 301);
            this.txtDestFolder.Multiline = true;
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.Size = new System.Drawing.Size(779, 75);
            this.txtDestFolder.TabIndex = 5;
            this.txtDestFolder.Text = "K:\\DestinationFolders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destination Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Other criteria: ";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(117, 167);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(668, 27);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.Text = "2Y6H";
            this.tTips.SetToolTip(this.txtFilter, "key words separated by semi-color (;) for OR selections. Leave this text box blan" +
        "k to copy all files.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "File Extension:";
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(117, 134);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(130, 27);
            this.txtExt.TabIndex = 8;
            this.txtExt.Text = "*.inp";
            this.tTips.SetToolTip(this.txtExt, "Extension of the file to be selected");
            // 
            // txtFilterNames
            // 
            this.txtFilterNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterNames.Location = new System.Drawing.Point(165, 200);
            this.txtFilterNames.Name = "txtFilterNames";
            this.txtFilterNames.Size = new System.Drawing.Size(620, 27);
            this.txtFilterNames.TabIndex = 10;
            this.txtFilterNames.Text = "K:\\FilesToCopy.csv";
            this.tTips.SetToolTip(this.txtFilterNames, "Additional key list to filter out all the files not having first five letter in t" +
        "he file names. To copy all, simply leave this text box blank");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Key Names for copy: ";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblStatus.Location = new System.Drawing.Point(14, 398);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(575, 26);
            this.lblStatus.TabIndex = 11;
            // 
            // txtMissedItems
            // 
            this.txtMissedItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMissedItems.Location = new System.Drawing.Point(165, 233);
            this.txtMissedItems.Name = "txtMissedItems";
            this.txtMissedItems.Size = new System.Drawing.Size(620, 27);
            this.txtMissedItems.TabIndex = 13;
            this.txtMissedItems.Text = "K:\\FilesToCopy_missed.csv";
            this.tTips.SetToolTip(this.txtMissedItems, "If any file listed in the \"Key Names to copy\", missing item names will be saved t" +
        "o this path.");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Save missed Items To: ";
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(632, 13);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(155, 31);
            this.btnLoadSettings.TabIndex = 14;
            this.btnLoadSettings.Text = "Load settings";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // frmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 432);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.txtMissedItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtFilterNames);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDestFolder);
            this.Controls.Add(this.txtDestFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSrcFolder);
            this.Controls.Add(this.txtSrcFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyFiles);
            this.Name = "frmCopyFile";
            this.Text = "Copy files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCopyFiles;
        private FolderBrowserDialog dgDir;
        private Label label1;
        private TextBox txtSrcFolder;
        private Button btnSrcFolder;
        private Button btnDestFolder;
        private TextBox txtDestFolder;
        private Label label2;
        private Label label3;
        private TextBox txtFilter;
        private Label label4;
        private TextBox txtExt;
        private TextBox txtFilterNames;
        private Label label5;
        private Label lblStatus;
        private TextBox txtMissedItems;
        private Label label6;
        private ToolTip tTips;
        private Button btnLoadSettings;
    }
}