using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            this.BackColor = Color.White;

            Button[] buttons = { btnStaff, btnCustomer, btnSupplier, btnProduct, btnImportDetail, btnOrderDetail, btnPayment };

            string basePath = Application.StartupPath;

            string[] icons = {
                Path.Combine(basePath, "Resources", "staff.png"),
                Path.Combine(basePath, "Resources", "customer.png"),
                Path.Combine(basePath, "Resources", "supplier.png"),
                Path.Combine(basePath, "Resources", "products.png"),
                Path.Combine(basePath, "Resources", "import.png"),
                Path.Combine(basePath, "Resources", "order.png"),
                Path.Combine(basePath, "Resources", "payment.png")
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].BackColor = Color.FromArgb(52, 152, 219); 
                buttons[i].ForeColor = Color.White;
                buttons[i].Font = new Font("Noto Sans Khmer", 18, FontStyle.Bold);
                buttons[i].Image = Image.FromFile(icons[i]);
                buttons[i].ImageAlign = ContentAlignment.MiddleLeft;
                buttons[i].TextAlign = ContentAlignment.MiddleRight;
                buttons[i].Height = 120;
                buttons[i].Width = 240;
                buttons[i].Padding = new Padding(10, 0, 10, 0);

                // Event handlers for hover
                buttons[i].MouseEnter += Button_MouseEnter;
                buttons[i].MouseLeave += Button_MouseLeave;
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Change background and text color
                btn.BackColor = Color.FromArgb(41, 128, 185);  // Darker Blue
                btn.ForeColor = Color.Yellow; // Change text color (you can use WhiteSmoke, etc.)
                btn.Cursor = Cursors.Hand;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Revert to original background and text color
                btn.BackColor = Color.FromArgb(52, 152, 219); // Original Blue
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Default;
            }
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

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            OrderDetailForm ordDetailForm = new OrderDetailForm(this);
            this.Hide();
            ordDetailForm.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(this);
            this.Hide();
            paymentForm.Show();
        }
    }
}
