using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_system
{
    public partial class ImportDetailForm : Form
    {
        MyOper d = new MyOper();
        public ImportDetailForm()
        {
            d.myConnection();
            InitializeComponent();
        }

        private void cboStaffId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string fullName = cboStaffID.SelectedValue.ToString();
            txtStaffName.Text = fullName;
            //SqlCommand com = new SqlCommand("SELECT ");
            //SqlDataReader dr = com.ExecuteReader();

        }

        private void ImportDetailForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataTable dt;
            //da = new SqlDataAdapter("SELECT staffID, FullName FROM dbo.tbStaffs",d.con); // use dbo here cus we uses service_broker and sql dependency
                                                                              // the reason we don't use sql script here cus our project is focus on thin client so the server side must be handle it
            da = new SqlDataAdapter("SELECT * FROM fnGetStaffs()", d.con);
            dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = null;
            cboStaffID.Items.Clear();
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID"; // selected value to display in cboStaffID
            cboStaffID.ValueMember = "FullName"; // the value to be selected and store in cboStaffID but the value to Display in it is ID
            //cboStaffID.SelectedIndex = -1; // Set to no selection
            cboStaffID.Text = null;


            da = new SqlDataAdapter("SELECT * FROM fnGetSuppliers()", d.con);
            dt = new DataTable();
            da.Fill(dt);
            cboSupName.DataSource = null;
            cboSupName.Items.Clear();
            cboSupName.DataSource = dt;
            cboSupName.DisplayMember = "supplier";
            cboSupName.ValueMember = "supID";
            cboSupName.Text = null;
        }

        private void cboSupName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSupID.Text = cboSupName.SelectedValue.ToString();
        }
    }
}
