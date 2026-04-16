namespace FileCompare
{
    partial class Form1
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
            lblAppName = new Label();
            txtLeftDir = new TextBox();
            btnLeftDir = new Button();
            lvwLeftDir = new ListView();
            name_left = new ColumnHeader();
            size_left = new ColumnHeader();
            date_left = new ColumnHeader();
            btnCopyFromRight = new Button();
            btnCopyFromLeft = new Button();
            lvwrightDir = new ListView();
            this.name_right = new ColumnHeader();
            this.size_right = new ColumnHeader();
            date_right = new ColumnHeader();
            btnRightDir = new Button();
            txtRightDir = new TextBox();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 20F);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(3, 6);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(353, 72);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLeftDir.Font = new Font("맑은 고딕", 12F);
            txtLeftDir.Location = new Point(14, 15);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(488, 50);
            txtLeftDir.TabIndex = 1;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnLeftDir.Location = new Point(524, 15);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(150, 53);
            btnLeftDir.TabIndex = 2;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { name_left, size_left, date_left });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(0, 0);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(674, 453);
            lvwLeftDir.TabIndex = 3;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // name_left
            // 
            name_left.Text = "이름";
            name_left.Width = 300;
            // 
            // size_left
            // 
            size_left.Text = "크기";
            size_left.Width = 120;
            // 
            // date_left
            // 
            date_left.Text = "수정일";
            date_left.Width = 220;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopyFromRight.Location = new Point(493, 20);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(150, 46);
            btnCopyFromRight.TabIndex = 4;
            btnCopyFromRight.Text = ">>>";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnCopyFromLeft.Location = new Point(15, 20);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(150, 46);
            btnCopyFromLeft.TabIndex = 4;
            btnCopyFromLeft.Text = "<<<";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            
            // 
            // lvwrightDir
            // 
            lvwrightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwrightDir.Columns.AddRange(new ColumnHeader[] { this.name_right, this.size_right, date_right });
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.Location = new Point(0, 0);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(670, 453);
            lvwrightDir.TabIndex = 3;
            lvwrightDir.UseCompatibleStateImageBehavior = false;
            lvwrightDir.View = View.Details;
            // 
            // name_right
            // 
            this.name_right.Text = "이름";
            this.name_right.Width = 300;
            // 
            // size_right
            // 
            this.size_right.Text = "크기";
            this.size_right.Width = 150;
            // 
            // date_right
            // 
            date_right.Text = "수정일";
            date_right.Width = 220;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnRightDir.Location = new Point(506, 15);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(150, 46);
            btnRightDir.TabIndex = 2;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Font = new Font("맑은 고딕", 12F);
            txtRightDir.Location = new Point(15, 15);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(446, 50);
            txtRightDir.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(30, 30);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new Size(1352, 622);
            splitContainer1.SplitterDistance = 676;
            splitContainer1.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(lvwLeftDir);
            panel3.Location = new Point(0, 167);
            panel3.Name = "panel3";
            panel3.Size = new Size(674, 453);
            panel3.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(txtLeftDir);
            panel2.Controls.Add(btnLeftDir);
            panel2.Location = new Point(0, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(674, 89);
            panel2.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnCopyFromRight);
            panel1.Controls.Add(lblAppName);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(674, 81);
            panel1.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(lvwrightDir);
            panel6.Location = new Point(0, 167);
            panel6.Name = "panel6";
            panel6.Size = new Size(670, 453);
            panel6.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(txtRightDir);
            panel5.Controls.Add(btnRightDir);
            panel5.Location = new Point(0, 81);
            panel5.Name = "panel5";
            panel5.Size = new Size(670, 89);
            panel5.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(btnCopyFromLeft);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(670, 81);
            panel4.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 682);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Padding = new Padding(30);
            Text = "File Compare v1.0";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblAppName;
        private TextBox txtLeftDir;
        private Button btnLeftDir;
        private ListView lvwLeftDir;
        private Button btnCopyFromRight;
        private Button btnCopyFromLeft;
        private ListView lvwrightDir;
        private Button btnRightDir;
        private TextBox txtRightDir;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private ColumnHeader name_left;
        private ColumnHeader size_left;
        private ColumnHeader date_left;
        private ColumnHeader name_right;
        private ColumnHeader size_right;
        private ColumnHeader date_right;
    }
}
