namespace macro
{
    partial class SignIn
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
            this.signin_signin_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.signin_pw_text_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.signin_id_text_box = new System.Windows.Forms.TextBox();
            this.signin_signup_button = new System.Windows.Forms.Button();
            this.signin_auto_sign_save_check_box = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // signin_signin_button
            // 
            this.signin_signin_button.Location = new System.Drawing.Point(323, 20);
            this.signin_signin_button.Name = "signin_signin_button";
            this.signin_signin_button.Size = new System.Drawing.Size(86, 43);
            this.signin_signin_button.TabIndex = 3;
            this.signin_signin_button.Text = "로그인";
            this.signin_signin_button.UseVisualStyleBackColor = true;
            this.signin_signin_button.Click += new System.EventHandler(this.signin_signin_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.signin_pw_text_box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.signin_id_text_box);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "로그인";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "비밀번호 : ";
            // 
            // signin_pw_text_box
            // 
            this.signin_pw_text_box.Location = new System.Drawing.Point(84, 44);
            this.signin_pw_text_box.Name = "signin_pw_text_box";
            this.signin_pw_text_box.PasswordChar = '*';
            this.signin_pw_text_box.Size = new System.Drawing.Size(198, 21);
            this.signin_pw_text_box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아이디 : ";
            // 
            // signin_id_text_box
            // 
            this.signin_id_text_box.Location = new System.Drawing.Point(84, 17);
            this.signin_id_text_box.Name = "signin_id_text_box";
            this.signin_id_text_box.Size = new System.Drawing.Size(198, 21);
            this.signin_id_text_box.TabIndex = 0;
            // 
            // signin_signup_button
            // 
            this.signin_signup_button.Location = new System.Drawing.Point(326, 103);
            this.signin_signup_button.Name = "signin_signup_button";
            this.signin_signup_button.Size = new System.Drawing.Size(87, 23);
            this.signin_signup_button.TabIndex = 5;
            this.signin_signup_button.Text = "회원가입";
            this.signin_signup_button.UseVisualStyleBackColor = true;
            this.signin_signup_button.Click += new System.EventHandler(this.signin_signup_button_Click);
            // 
            // signin_auto_sign_save_check_box
            // 
            this.signin_auto_sign_save_check_box.AutoSize = true;
            this.signin_auto_sign_save_check_box.Location = new System.Drawing.Point(325, 76);
            this.signin_auto_sign_save_check_box.Name = "signin_auto_sign_save_check_box";
            this.signin_auto_sign_save_check_box.Size = new System.Drawing.Size(88, 16);
            this.signin_auto_sign_save_check_box.TabIndex = 4;
            this.signin_auto_sign_save_check_box.Text = "자동 로그인";
            this.signin_auto_sign_save_check_box.UseVisualStyleBackColor = true;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(421, 138);
            this.Controls.Add(this.signin_auto_sign_save_check_box);
            this.Controls.Add(this.signin_signup_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.signin_signin_button);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.Load += new System.EventHandler(this.SignIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signin_signin_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox signin_pw_text_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox signin_id_text_box;
        private System.Windows.Forms.Button signin_signup_button;
        private System.Windows.Forms.CheckBox signin_auto_sign_save_check_box;
    }
}