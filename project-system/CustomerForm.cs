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
    public partial class CustomerForm : Form
    {
        MyOper op = new MyOper();  // create object of class MyOper to manage database connection
        SqlCommand com;
        SqlDataAdapter dap;
        DataTable dt;
        public CustomerForm()
        {
            op.myConnection();
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            this.dgvCus.DefaultCellStyle.Font = new Font("Noto Sans Khmer", 10);
            this.dgvCus.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans Khmer", 10, FontStyle.Bold);
            dgvCus.DataSource = null;
            com = new SqlCommand("spGetCustomers", op.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDependency dep = new SqlDependency(com);
            dep.OnChange += new OnChangeEventHandler(onChange);
            SqlDataAdapter depp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            depp.Fill(dt);
            dgvCus.DataSource = dt;
        }

        public void onChange(Object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvCus.BeginInvoke(new MethodInvoker(loadData));
            }
            else
            {
                loadData();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
