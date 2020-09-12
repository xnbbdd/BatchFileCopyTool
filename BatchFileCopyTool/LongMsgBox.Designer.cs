namespace BatchFileCopyTool
{
    partial class LongMsgBox
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
            this.LongMsgTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new MetroFramework.Controls.MetroButton();
            this.CanlceButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // LongMsgTextBox
            // 
            this.LongMsgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LongMsgTextBox.Location = new System.Drawing.Point(24, 96);
            this.LongMsgTextBox.Multiline = true;
            this.LongMsgTextBox.Name = "LongMsgTextBox";
            this.LongMsgTextBox.ReadOnly = true;
            this.LongMsgTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LongMsgTextBox.Size = new System.Drawing.Size(325, 291);
            this.LongMsgTextBox.TabIndex = 0;
            this.LongMsgTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "确认复制下列文件？";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(153, 404);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 35);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "确认";
            this.OKButton.UseSelectable = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CanlceButton
            // 
            this.CanlceButton.Location = new System.Drawing.Point(253, 404);
            this.CanlceButton.Name = "CanlceButton";
            this.CanlceButton.Size = new System.Drawing.Size(75, 35);
            this.CanlceButton.TabIndex = 3;
            this.CanlceButton.Text = "取消";
            this.CanlceButton.UseSelectable = true;
            this.CanlceButton.Click += new System.EventHandler(this.CanlceButton_Click);
            // 
            // LongMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 450);
            this.Controls.Add(this.CanlceButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LongMsgTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(372, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(372, 450);
            this.Name = "LongMsgBox";
            this.Text = "确认复制";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LongMsgBox_FormClosed);
            this.Load += new System.EventHandler(this.LongMsgBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LongMsgTextBox;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton OKButton;
        private MetroFramework.Controls.MetroButton CanlceButton;
    }
}