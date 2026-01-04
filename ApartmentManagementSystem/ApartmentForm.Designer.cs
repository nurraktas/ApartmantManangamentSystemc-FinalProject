namespace ApartmentManagementSystem
{
    partial class ApartmentForm
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
            this.grpApartmentInfo = new System.Windows.Forms.GroupBox();
            this.chkIsOcuupied = new System.Windows.Forms.CheckBox();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.txtApertmentNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvApartments = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenantPhone = new System.Windows.Forms.TextBox();
            this.btnOpenTenantForm = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.grpApartmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartments)).BeginInit();
            this.SuspendLayout();
            // 
            // grpApartmentInfo
            // 
            this.grpApartmentInfo.Controls.Add(this.chkIsOcuupied);
            this.grpApartmentInfo.Controls.Add(this.txtFloor);
            this.grpApartmentInfo.Controls.Add(this.txtApertmentNo);
            this.grpApartmentInfo.Controls.Add(this.label2);
            this.grpApartmentInfo.Controls.Add(this.label1);
            this.grpApartmentInfo.Location = new System.Drawing.Point(20, 20);
            this.grpApartmentInfo.Name = "grpApartmentInfo";
            this.grpApartmentInfo.Size = new System.Drawing.Size(300, 180);
            this.grpApartmentInfo.TabIndex = 0;
            this.grpApartmentInfo.TabStop = false;
            this.grpApartmentInfo.Text = "Apartment Information ";
            // 
            // chkIsOcuupied
            // 
            this.chkIsOcuupied.AutoSize = true;
            this.chkIsOcuupied.Location = new System.Drawing.Point(130, 105);
            this.chkIsOcuupied.Name = "chkIsOcuupied";
            this.chkIsOcuupied.Size = new System.Drawing.Size(100, 20);
            this.chkIsOcuupied.TabIndex = 1;
            this.chkIsOcuupied.Text = "Is Occupied";
            this.chkIsOcuupied.UseVisualStyleBackColor = true;
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(130, 67);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(130, 22);
            this.txtFloor.TabIndex = 2;
            // 
            // txtApertmentNo
            // 
            this.txtApertmentNo.Location = new System.Drawing.Point(130, 27);
            this.txtApertmentNo.Name = "txtApertmentNo";
            this.txtApertmentNo.Size = new System.Drawing.Size(130, 22);
            this.txtApertmentNo.TabIndex = 1;
            this.txtApertmentNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Floor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aparment No:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(20, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(170, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 35);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvApartments
            // 
            this.dgvApartments.AllowUserToAddRows = false;
            this.dgvApartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApartments.Location = new System.Drawing.Point(350, 20);
            this.dgvApartments.MultiSelect = false;
            this.dgvApartments.Name = "dgvApartments";
            this.dgvApartments.ReadOnly = true;
            this.dgvApartments.RowHeadersWidth = 51;
            this.dgvApartments.RowTemplate.Height = 24;
            this.dgvApartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApartments.Size = new System.Drawing.Size(420, 400);
            this.dgvApartments.TabIndex = 4;
            this.dgvApartments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApartments_CellClick);
            this.dgvApartments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApartments_CellContentClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(20, 279);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(170, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tenant Name ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtTenantName
            // 
            this.txtTenantName.BackColor = System.Drawing.Color.White;
            this.txtTenantName.Location = new System.Drawing.Point(110, 343);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.ReadOnly = true;
            this.txtTenantName.Size = new System.Drawing.Size(220, 22);
            this.txtTenantName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Phone";
            // 
            // txtTenantPhone
            // 
            this.txtTenantPhone.BackColor = System.Drawing.Color.White;
            this.txtTenantPhone.Location = new System.Drawing.Point(110, 381);
            this.txtTenantPhone.Name = "txtTenantPhone";
            this.txtTenantPhone.ReadOnly = true;
            this.txtTenantPhone.Size = new System.Drawing.Size(220, 22);
            this.txtTenantPhone.TabIndex = 11;
            // 
            // btnOpenTenantForm
            // 
            this.btnOpenTenantForm.Location = new System.Drawing.Point(225, 409);
            this.btnOpenTenantForm.Name = "btnOpenTenantForm";
            this.btnOpenTenantForm.Size = new System.Drawing.Size(105, 23);
            this.btnOpenTenantForm.TabIndex = 12;
            this.btnOpenTenantForm.Text = "Add";
            this.btnOpenTenantForm.UseVisualStyleBackColor = true;
            this.btnOpenTenantForm.Click += new System.EventHandler(this.btnOpenTenantForm_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(110, 409);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(81, 32);
            this.btnAddPayment.TabIndex = 13;
            this.btnAddPayment.Text = " Payment";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // ApartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.btnOpenTenantForm);
            this.Controls.Add(this.txtTenantPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenantName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvApartments);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpApartmentInfo);
            this.Name = "ApartmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApartmentForm";
            this.Load += new System.EventHandler(this.ApartmentForm_Load);
            this.grpApartmentInfo.ResumeLayout(false);
            this.grpApartmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpApartmentInfo;
        private System.Windows.Forms.TextBox txtApertmentNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkIsOcuupied;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvApartments;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenantName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenantPhone;
        private System.Windows.Forms.Button btnOpenTenantForm;
        private System.Windows.Forms.Button btnAddPayment;
    }
}