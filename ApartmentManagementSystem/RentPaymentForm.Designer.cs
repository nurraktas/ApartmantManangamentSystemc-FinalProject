namespace ApartmentManagementSystem
{
    partial class RentPaymentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTenants = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsPaid = new System.Windows.Forms.CheckBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.btnMarkAsPaid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tenant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount ";
            // 
            // cmbTenants
            // 
            this.cmbTenants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenants.FormattingEnabled = true;
            this.cmbTenants.Location = new System.Drawing.Point(178, 47);
            this.cmbTenants.Name = "cmbTenants";
            this.cmbTenants.Size = new System.Drawing.Size(261, 24);
            this.cmbTenants.TabIndex = 2;
            this.cmbTenants.SelectedIndexChanged += new System.EventHandler(this.cmbTenants_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(178, 104);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(261, 22);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment Date";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(178, 162);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(222, 22);
            this.dtpPaymentDate.TabIndex = 5;
            // 
            // chkIsPaid
            // 
            this.chkIsPaid.AutoSize = true;
            this.chkIsPaid.Location = new System.Drawing.Point(200, 220);
            this.chkIsPaid.Name = "chkIsPaid";
            this.chkIsPaid.Size = new System.Drawing.Size(60, 20);
            this.chkIsPaid.TabIndex = 6;
            this.chkIsPaid.Text = "Paid ";
            this.chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(200, 311);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(180, 45);
            this.btnAddPayment.TabIndex = 7;
            this.btnAddPayment.Text = "AddPayment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // dgvPayments
            // 
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Location = new System.Drawing.Point(476, 47);
            this.dgvPayments.MultiSelect = false;
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersWidth = 51;
            this.dgvPayments.RowTemplate.Height = 24;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(266, 249);
            this.dgvPayments.TabIndex = 8;
            this.dgvPayments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayments_CellClick);
            // 
            // btnMarkAsPaid
            // 
            this.btnMarkAsPaid.BackColor = System.Drawing.Color.Red;
            this.btnMarkAsPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsPaid.Location = new System.Drawing.Point(595, 342);
            this.btnMarkAsPaid.Name = "btnMarkAsPaid";
            this.btnMarkAsPaid.Size = new System.Drawing.Size(131, 31);
            this.btnMarkAsPaid.TabIndex = 9;
            this.btnMarkAsPaid.Text = "Mark as Paid";
            this.btnMarkAsPaid.UseVisualStyleBackColor = false;
            this.btnMarkAsPaid.Click += new System.EventHandler(this.btnMarkAsPaid_Click);
            // 
            // RentPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(771, 403);
            this.Controls.Add(this.btnMarkAsPaid);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.chkIsPaid);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbTenants);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "RentPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentPaymentForm";
            this.Load += new System.EventHandler(this.RentPaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTenants;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.CheckBox chkIsPaid;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Button btnMarkAsPaid;
    }
}