namespace VideoConverter
{
    partial class Form1
    {
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.CheckBox chkIncludeSubfolders;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RadioButton rbtnSameFrames;
        private System.Windows.Forms.RadioButton rbtnSameDuration;
        private System.Windows.Forms.CheckBox chkOutputMp4;
        private System.Windows.Forms.CheckBox chkOutputGif;
        private System.Windows.Forms.CheckBox chkGenerateHtml;
        private System.Windows.Forms.CheckBox chkOutputPngSeq;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGifScale;
        private System.Windows.Forms.TextBox txtGifScale;
        private System.Windows.Forms.Label coment1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.chkIncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rbtnSameFrames = new System.Windows.Forms.RadioButton();
            this.rbtnSameDuration = new System.Windows.Forms.RadioButton();
            this.chkOutputMp4 = new System.Windows.Forms.CheckBox();
            this.chkOutputGif = new System.Windows.Forms.CheckBox();
            this.chkGenerateHtml = new System.Windows.Forms.CheckBox();
            this.chkOutputPngSeq = new System.Windows.Forms.CheckBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGifScale = new System.Windows.Forms.Label();
            this.txtGifScale = new System.Windows.Forms.TextBox();
            this.coment1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 27);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "フォルダ選択";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(93, 29);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(395, 19);
            this.txtFolderPath.TabIndex = 1;
            // 
            // chkIncludeSubfolders
            // 
            this.chkIncludeSubfolders.AutoSize = true;
            this.chkIncludeSubfolders.Checked = true;
            this.chkIncludeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubfolders.Location = new System.Drawing.Point(12, 57);
            this.chkIncludeSubfolders.Name = "chkIncludeSubfolders";
            this.chkIncludeSubfolders.Size = new System.Drawing.Size(109, 16);
            this.chkIncludeSubfolders.TabIndex = 2;
            this.chkIncludeSubfolders.Text = "サブフォルダを含む";
            this.chkIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(476, 23);
            this.progressBar.TabIndex = 3;
            // 
            // rbtnSameFrames
            // 
            this.rbtnSameFrames.AutoSize = true;
            this.rbtnSameFrames.Checked = true;
            this.rbtnSameFrames.Location = new System.Drawing.Point(12, 110);
            this.rbtnSameFrames.Name = "rbtnSameFrames";
            this.rbtnSameFrames.Size = new System.Drawing.Size(93, 16);
            this.rbtnSameFrames.TabIndex = 4;
            this.rbtnSameFrames.TabStop = true;
            this.rbtnSameFrames.Text = "同じフレーム数";
            this.rbtnSameFrames.UseVisualStyleBackColor = true;
            // 
            // rbtnSameDuration
            // 
            this.rbtnSameDuration.AutoSize = true;
            this.rbtnSameDuration.Location = new System.Drawing.Point(105, 110);
            this.rbtnSameDuration.Name = "rbtnSameDuration";
            this.rbtnSameDuration.Size = new System.Drawing.Size(80, 16);
            this.rbtnSameDuration.TabIndex = 5;
            this.rbtnSameDuration.TabStop = true;
            this.rbtnSameDuration.Text = "同じ時間長";
            this.rbtnSameDuration.UseVisualStyleBackColor = true;
            // 
            // chkOutputMp4
            // 
            this.chkOutputMp4.AutoSize = true;
            this.chkOutputMp4.Checked = true;
            this.chkOutputMp4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutputMp4.Location = new System.Drawing.Point(12, 133);
            this.chkOutputMp4.Name = "chkOutputMp4";
            this.chkOutputMp4.Size = new System.Drawing.Size(79, 16);
            this.chkOutputMp4.TabIndex = 6;
            this.chkOutputMp4.Text = "MP4を出力";
            this.chkOutputMp4.UseVisualStyleBackColor = true;
            this.chkOutputMp4.CheckedChanged += new System.EventHandler(this.chkOutputMp4_CheckedChanged);
            // 
            // chkOutputGif
            // 
            this.chkOutputGif.AutoSize = true;
            this.chkOutputGif.Checked = true;
            this.chkOutputGif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutputGif.Location = new System.Drawing.Point(93, 133);
            this.chkOutputGif.Name = "chkOutputGif";
            this.chkOutputGif.Size = new System.Drawing.Size(75, 16);
            this.chkOutputGif.TabIndex = 7;
            this.chkOutputGif.Text = "GIFを出力";
            this.chkOutputGif.UseVisualStyleBackColor = true;
            this.chkOutputGif.CheckedChanged += new System.EventHandler(this.chkOutputGif_CheckedChanged);
            // 
            // chkGenerateHtml
            // 
            this.chkGenerateHtml.AutoSize = true;
            this.chkGenerateHtml.Checked = true;
            this.chkGenerateHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateHtml.Location = new System.Drawing.Point(174, 133);
            this.chkGenerateHtml.Name = "chkGenerateHtml";
            this.chkGenerateHtml.Size = new System.Drawing.Size(106, 16);
            this.chkGenerateHtml.TabIndex = 8;
            this.chkGenerateHtml.Text = "HTMLを生成する";
            this.chkGenerateHtml.UseVisualStyleBackColor = true;
            // 
            // chkOutputPngSeq
            // 
            this.chkOutputPngSeq.AutoSize = true;
            this.chkOutputPngSeq.Checked = true;
            this.chkOutputPngSeq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutputPngSeq.Location = new System.Drawing.Point(12, 155);
            this.chkOutputPngSeq.Name = "chkOutputPngSeq";
            this.chkOutputPngSeq.Size = new System.Drawing.Size(109, 16);
            this.chkOutputPngSeq.TabIndex = 9;
            this.chkOutputPngSeq.Text = "連番PNG書き出し";
            this.chkOutputPngSeq.UseVisualStyleBackColor = true;
            this.chkOutputPngSeq.CheckedChanged += new System.EventHandler(this.chkOutputPngSeq_CheckedChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 199);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(109, 41);
            this.btnConvert.TabIndex = 12;
            this.btnConvert.Text = "実行";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(127, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 41);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "中止";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblGifScale
            // 
            this.lblGifScale.AutoSize = true;
            this.lblGifScale.Location = new System.Drawing.Point(295, 134);
            this.lblGifScale.Name = "lblGifScale";
            this.lblGifScale.Size = new System.Drawing.Size(49, 12);
            this.lblGifScale.TabIndex = 10;
            this.lblGifScale.Text = "GIF倍率:";
            // 
            // txtGifScale
            // 
            this.txtGifScale.Location = new System.Drawing.Point(355, 131);
            this.txtGifScale.Name = "txtGifScale";
            this.txtGifScale.Size = new System.Drawing.Size(54, 19);
            this.txtGifScale.TabIndex = 11;
            this.txtGifScale.Text = "0.2";
            // 
            // coment1
            // 
            this.coment1.AutoSize = true;
            this.coment1.Location = new System.Drawing.Point(13, 9);
            this.coment1.Name = "coment1";
            this.coment1.Size = new System.Drawing.Size(209, 12);
            this.coment1.TabIndex = 14;
            this.coment1.Text = "Avi、Mov、Mp4を30fpsのmp4に変換します";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 252);
            this.Controls.Add(this.coment1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkOutputMp4);
            this.Controls.Add(this.chkOutputGif);
            this.Controls.Add(this.chkGenerateHtml);
            this.Controls.Add(this.chkOutputPngSeq);
            this.Controls.Add(this.lblGifScale);
            this.Controls.Add(this.txtGifScale);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.rbtnSameDuration);
            this.Controls.Add(this.rbtnSameFrames);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chkIncludeSubfolders);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnSelectFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "30fpsMP4に変換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
