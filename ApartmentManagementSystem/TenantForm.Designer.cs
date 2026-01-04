namespace ApartmentManagementSystem
{
    partial class TenantForm
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
            this.grpTenantInfo = new System.Windows.Forms.GroupBox();
            this.cmbApartments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTeant = new System.Windows.Forms.Button();
            this.btnUpdateTenant = new System.Windows.Forms.Button();
            this.btnClearTernant = new System.Windows.Forms.Button();
            this.btnDeleteTernant = new System.Windows.Forms.Button();
            this.dgvTenants = new System.Windows.Forms.DataGridView();
            this.grpTenantInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTenants)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTenantInfo
            // 
            this.grpTenantInfo.Controls.Add(this.cmbApartments);
            this.grpTenantInfo.Controls.Add(this.label3);
            this.grpTenantInfo.Controls.Add(this.txtPhone);
            this.grpTenantInfo.Controls.Add(this.label2);
            this.grpTenantInfo.Controls.Add(this.TxtFullName);
            this.grpTenantInfo.Controls.Add(this.label1);
            this.grpTenantInfo.Location = new System.Drawing.Point(20, 57);
            this.grpTenantInfo.Name = "grpTenantInfo";
            this.grpTenantInfo.Size = new System.Drawing.Size(299, 238);
            this.grpTenantInfo.TabIndex = 7;
            this.grpTenantInfo.TabStop = false;
            this.grpTenantInfo.Text = "Tenant Information";
            // 
            // cmbApartments
            // 
            this.cmbApartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApartments.FormattingEnabled = true;
            this.cmbApartments.Location = new System.Drawing.Point(20, 165);
            this.cmbApartments.Name = "cmbApartments";
            this.cmbApartments.Size = new System.Drawing.Size(200, 24);
            this.cmbApartments.TabIndex = 10;
            this.cmbApartments.SelectedIndexChanged += new System.EventHandler(this.cmbApartments_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Apartment";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(80, 87);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 22);
            this.txtPhone.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // TxtFullName
            // 
            this.TxtFullName.Location = new System.Drawing.Point(80, 34);
            this.TxtFullName.Name = "TxtFullName";
            this.TxtFullName.Size = new System.Drawing.Size(200, 22);
            this.TxtFullName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Full Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddTeant
            // 
            this.btnAddTeant.Location = new System.Drawing.Point(338, 75);
            this.btnAddTeant.Name = "btnAddTeant";
            this.btnAddTeant.Size = new System.Drawing.Size(100, 35);
            this.btnAddTeant.TabIndex = 8;
            this.btnAddTeant.Text = "Add";
            this.btnAddTeant.UseVisualStyleBackColor = true;
            this.btnAddTeant.Click += new System.EventHandler(this.btnAddTeant_Click);
            // 
            // btnUpdateTenant
            // 
            this.btnUpdateTenant.Location = new System.Drawing.Point(338, 125);
            this.btnUpdateTenant.Name = "btnUpdateTenant";
            this.btnUpdateTenant.Size = new System.Drawing.Size(100, 35);
            this.btnUpdateTenant.TabIndex = 9;
            this.btnUpdateTenant.Text = "Update";
            this.btnUpdateTenant.UseVisualStyleBackColor = true;
            this.btnUpdateTenant.Click += new System.EventHandler(this.btnUpdateTenant_Click);
            // 
            // btnClearTernant
            // 
            this.btnClearTernant.Location = new System.Drawing.Point(338, 242);
            this.btnClearTernant.Name = "btnClearTernant";
            this.btnClearTernant.Size = new System.Drawing.Size(100, 35);
            this.btnClearTernant.TabIndex = 10;
            this.btnClearTernant.Text = "Clear";
            this.btnClearTernant.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTernant
            // 
            this.btnDeleteTernant.Location = new System.Drawing.Point(338, 183);
            this.btnDeleteTernant.Name = "btnDeleteTernant";
            this.btnDeleteTernant.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteTernant.TabIndex = 11;
            this.btnDeleteTernant.Text = "Delete";
            this.btnDeleteTernant.UseVisualStyleBackColor = true;
            this.btnDeleteTernant.Click += new System.EventHandler(this.btnDeleteTernant_Click);
            // 
            // dgvTenants
            // 
            this.dgvTenants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTenants.Location = new System.Drawing.Point(472, 57);
            this.dgvTenants.MultiSelect = false;
            this.dgvTenants.Name = "dgvTenants";
            this.dgvTenants.ReadOnly = true;
            this.dgvTenants.RowHeadersWidth = 51;
            this.dgvTenants.RowTemplate.Height = 24;
            this.dgvTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTenants.Size = new System.Drawing.Size(288, 238);
            this.dgvTenants.TabIndex = 12;
            this.dgvTenants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTenants_CellClick);
            // 
            // TenantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 369);
            this.Controls.Add(this.dgvTenants);
            this.Controls.Add(this.btnDeleteTernant);
            this.Controls.Add(this.btnClearTernant);
            this.Controls.Add(this.btnUpdateTenant);
            this.Controls.Add(this.btnAddTeant);
            this.Controls.Add(this.grpTenantInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "TenantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Tenant";
            this.Load += new System.EventHandler(this.TenantForm_Load);
            this.grpTenantInfo.ResumeLayout(false);
            this.grpTenantInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTenants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpTenantInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbApartments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddTeant;
        private System.Windows.Forms.Button btnUpdateTenant;
        private System.Windows.Forms.Button btnClearTernant;
        private System.Windows.Forms.Button btnDeleteTernant;
        private System.Windows.Forms.DataGridView dgvTenants;
    }
}