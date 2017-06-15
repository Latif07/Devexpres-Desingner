namespace Oti.Sas.ContractDesigner {
    partial class frmContractDesigner {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractDesigner));
            this.grbxLogin = new System.Windows.Forms.GroupBox();
            this.bntLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.grbxContracts = new System.Windows.Forms.GroupBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.cmbContracts = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.grbxLogin.SuspendLayout();
            this.grbxContracts.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxLogin
            // 
            this.grbxLogin.Controls.Add(this.bntLogin);
            this.grbxLogin.Controls.Add(this.label2);
            this.grbxLogin.Controls.Add(this.label1);
            this.grbxLogin.Controls.Add(this.txtPassword);
            this.grbxLogin.Controls.Add(this.txtUserName);
            this.grbxLogin.Location = new System.Drawing.Point(26, 29);
            this.grbxLogin.Name = "grbxLogin";
            this.grbxLogin.Size = new System.Drawing.Size(280, 129);
            this.grbxLogin.TabIndex = 1;
            this.grbxLogin.TabStop = false;
            this.grbxLogin.Text = "Login";
            // 
            // bntLogin
            // 
            this.bntLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bntLogin.Location = new System.Drawing.Point(190, 75);
            this.bntLogin.Name = "bntLogin";
            this.bntLogin.Size = new System.Drawing.Size(75, 23);
            this.bntLogin.TabIndex = 4;
            this.bntLogin.Text = "Login";
            this.bntLogin.UseVisualStyleBackColor = true;
            this.bntLogin.Click += new System.EventHandler(this.bntLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(89, 49);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(174, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(89, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(174, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // grbxContracts
            // 
            this.grbxContracts.Controls.Add(this.btnLogout);
            this.grbxContracts.Controls.Add(this.btnContract);
            this.grbxContracts.Controls.Add(this.cmbContracts);
            this.grbxContracts.Location = new System.Drawing.Point(26, 164);
            this.grbxContracts.Name = "grbxContracts";
            this.grbxContracts.Size = new System.Drawing.Size(280, 90);
            this.grbxContracts.TabIndex = 2;
            this.grbxContracts.TabStop = false;
            this.grbxContracts.Text = "Contract Selection";
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogout.Location = new System.Drawing.Point(190, 43);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnContract
            // 
            this.btnContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnContract.Location = new System.Drawing.Point(17, 43);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(120, 23);
            this.btnContract.TabIndex = 5;
            this.btnContract.Text = "Open Contract";
            this.btnContract.UseVisualStyleBackColor = true;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // cmbContracts
            // 
            this.cmbContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContracts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContracts.FormattingEnabled = true;
            this.cmbContracts.Location = new System.Drawing.Point(17, 16);
            this.cmbContracts.Name = "cmbContracts";
            this.cmbContracts.Size = new System.Drawing.Size(248, 21);
            this.cmbContracts.TabIndex = 3;
            this.cmbContracts.SelectedIndexChanged += new System.EventHandler(this.cmbContracts_SelectedIndexChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(108, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            this.lblInfo.TabIndex = 3;
            // 
            // frmContractDesigner
            // 
            this.AcceptButton = this.bntLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 275);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grbxContracts);
            this.Controls.Add(this.grbxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContractDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract Designer";
            this.Load += new System.EventHandler(this.frmContractDesigner_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmContractDesigner_KeyUp);
            this.grbxLogin.ResumeLayout(false);
            this.grbxLogin.PerformLayout();
            this.grbxContracts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxLogin;
        private System.Windows.Forms.Button bntLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox grbxContracts;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.ComboBox cmbContracts;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnLogout;


    }
}

