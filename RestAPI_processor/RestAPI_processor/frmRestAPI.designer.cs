namespace RestAPI_processor
{
    partial class frmRestAPI
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebPage = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.popFld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uStateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uZip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 88);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(775, 35);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(63, 4);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(732, 22);
            this.txtURL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Web page:";
            // 
            // txtWebPage
            // 
            this.txtWebPage.Location = new System.Drawing.Point(100, 42);
            this.txtWebPage.Name = "txtWebPage";
            this.txtWebPage.Size = new System.Drawing.Size(695, 22);
            this.txtWebPage.TabIndex = 4;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(632, 505);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(163, 30);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Content:";
            // 
            // dgView
            // 
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.popFld,
            this.uPlace,
            this.uState,
            this.uStateCode,
            this.uZip});
            this.dgView.Location = new System.Drawing.Point(20, 129);
            this.dgView.Name = "dgView";
            this.dgView.RowTemplate.Height = 24;
            this.dgView.Size = new System.Drawing.Size(775, 370);
            this.dgView.TabIndex = 7;
            // 
            // popFld
            // 
            this.popFld.HeaderText = "Population";
            this.popFld.Name = "popFld";
            // 
            // uPlace
            // 
            this.uPlace.HeaderText = "Place";
            this.uPlace.Name = "uPlace";
            this.uPlace.Width = 350;
            // 
            // uState
            // 
            this.uState.HeaderText = "State";
            this.uState.Name = "uState";
            // 
            // uStateCode
            // 
            this.uStateCode.HeaderText = "State Code";
            this.uStateCode.Name = "uStateCode";
            this.uStateCode.Width = 60;
            // 
            // uZip
            // 
            this.uZip.HeaderText = "Zip code";
            this.uZip.Name = "uZip";
            this.uZip.Width = 80;
            // 
            // frmRestAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 538);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtWebPage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmRestAPI";
            this.Text = "Rest API test";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWebPage;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.DataGridViewTextBoxColumn popFld;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn uState;
        private System.Windows.Forms.DataGridViewTextBoxColumn uStateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn uZip;
    }
}

