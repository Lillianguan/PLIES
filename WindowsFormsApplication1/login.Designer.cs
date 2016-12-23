namespace WindowsFormsApplication1
{
    partial class Login
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Username";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Passwort";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // username
            // 
            this.username.AutoCompleteCustomSource.AddRange(new string[] {
            "Lillian__guan@163.com"});
            this.username.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.username.Location = new System.Drawing.Point(108, 55);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(127, 20);
            this.username.TabIndex = 2;
            // 
            // password
            // 
            this.password.AutoCompleteCustomSource.AddRange(new string[] {
            "standap-guan"});
            this.password.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.password.Location = new System.Drawing.Point(108, 100);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(127, 20);
            this.password.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 221);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(83, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = " Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox username;
        public System.Windows.Forms.TextBox password;
    }
}