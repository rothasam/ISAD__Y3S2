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
    public partial class StaffForm : Form
    {
        MyOper op = new MyOper();
        SqlCommand com; // read data from store procedure
        SqlDataAdapter dap; // also read data
        DataTable dt; // add data to datagridview


        public StaffForm()
        {
            op.myConnection();
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgvStaff.DataSource = null;
            com = new SqlCommand("spGetStaffs", op.con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDependency dep = new SqlDependency(com);
            dep.OnChange += new OnChangeEventHandler(onChange);

            SqlDataAdapter depp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            depp.Fill(dt);
            dgvStaff.DataSource = dt;


            /*
             in sql server when using service brokder we cannot use * to select data but its real column name. 
            => go to sql and right click on file store procedure then click modify. Next change * and add column name 
             */
        }
        public void onChange(Object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvStaff.BeginInvoke(new MethodInvoker(loadData));
            }
            else
            {
                loadData();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }
    }
}
