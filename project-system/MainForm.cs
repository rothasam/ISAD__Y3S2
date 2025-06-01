using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_system
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffForm frmStaff = new StaffForm(this);
            this.Hide();
            frmStaff.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm frmCustomer = new CustomerForm(this);
            this.Hide();
            frmCustomer.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm frmSupplier = new SupplierForm(this);
            this.Hide();
            frmSupplier.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm frmProduct = new ProductForm(this);
            this.Hide();
            frmProduct.Show();
        }

        private void btnImportDetail_Click(object sender, EventArgs e)
        {
            ImportDetailForm impDetailForm = new ImportDetailForm(this);
            this.Hide();
            impDetailForm.Show();
        }
    }
}
