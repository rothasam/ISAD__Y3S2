using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_system
{
    public partial class SupplierForm : Form
    {
        MyOper op = new MyOper();
        SqlCommand com;
        SqlDataAdapter dap;
        DataTable dt;

        public SupplierForm()
        {
            op.myConnection();
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            this.dgvSup.DefaultCellStyle.Font = new Font("Noto Sans Khmer", 10);
            this.dgvSup.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans Khmer", 10, FontStyle.Bold);
            dgvSup.DataSource = null;
            com = new SqlCommand("spGetSuppliers", op.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDependency dep = new SqlDependency(com);
            dep.OnChange += new OnChangeEventHandler(onChange);
            SqlDataAdapter depp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            depp.Fill(dt);
            dgvSup.DataSource = dt;
        }

        public void onChange(Object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvSup.BeginInvoke(new MethodInvoker(loadData));
            }
            else
            {
                loadData();
            }
        }

        private void onAddNew(object sender, EventArgs e)
        {
            com = new SqlCommand("spSetSupplier", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@nameSup", txtName.Text);
            com.Parameters.AddWithValue("@address", txtAddress.Text);
            com.Parameters.AddWithValue("@contact", txtContact.Text);

            com.ExecuteNonQuery();// run stored procedure
            MessageBox.Show("Supplier added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onSearch(object sender, EventArgs e)
        {
            (dgvSup.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                "Supplier LIKE '%{0}%'", txtSearch.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
