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
        MyOper op = new MyOper();
        private MainForm mainForm;
        SqlCommand cmd; 
        public ImportDetailForm(MainForm mainForm)
        {
            op.myConnection();
            InitializeComponent();
            this.mainForm = mainForm;
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
            //da = new SqlDataAdapter("sql statement here..",d.con); // use dbo.tbname here cus we uses service_broker and sql dependency
                                                                              // the reason we don't use sql script here cus our project is focus on thin client so the server side must be handle it
            da = new SqlDataAdapter("SELECT * FROM fnGetStaffs()", op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = null;
            cboStaffID.Items.Clear();
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID"; // selected value to display in cboStaffID
            cboStaffID.ValueMember = "FullName"; // the value to be selected and store in cboStaffID but the value to Display in it is ID
            //cboStaffID.SelectedIndex = -1; // Set to no selection
            cboStaffID.Text = null;


            da = new SqlDataAdapter("SELECT * FROM fnGetSuppliers()", op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboSupName.DataSource = null;
            cboSupName.Items.Clear();
            cboSupName.DataSource = dt;
            cboSupName.DisplayMember = "supplier";
            cboSupName.ValueMember = "supID";
            cboSupName.Text = null;


            listViewImpDetail.View = View.Details; // set view to details
            //listViewImpDetail.FullRowSelect = true; // select full row
            //listViewImpDetail.GridLines = true; // show grid lines
            //listViewImpDetail.Columns.Clear(); // resetting
            listViewImpDetail.Columns.Add("Pro ID",100);
            listViewImpDetail.Columns.Add("Name",100);
            listViewImpDetail.Columns.Add("Qty",100);
            listViewImpDetail.Columns.Add("Price",100);
            listViewImpDetail.Columns.Add("Amount",100);
        }

        private void cboSupName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSupID.Text = cboSupName.SelectedValue.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void txtProID_TextChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM fnGetProNameById(@proCode)", op.con);
            cmd.Parameters.AddWithValue("@proCode", txtProID.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtPro.Text = dr["ProName"].ToString();
                }
            }
            else
            {
                txtPro.Text = "";
            }
            //dr.Close();
            dr.Dispose();
            cmd.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string impDate = dtpImpDate.Value.ToString("yyyy-MM-dd");
            int staffId = int.Parse(cboStaffID.Text);
            string staffName = txtStaffName.Text;
            int supId = int.Parse(cboSupName.SelectedValue.ToString());
            string supName = cboSupName.Text;
            int proId = int.Parse(txtProID.Text);
            string proName = txtPro.Text;
            int qty = int.Parse(txtQty.Text);
            decimal price = decimal.Parse(txtInStockPrice.Text);
            decimal amount = qty * price;

            // Method 1
            /*
                ListViewItem item = new ListViewItem(proId.ToString()); // insert in the first column in listview
                item.SubItems.Add(proName);
                item.SubItems.Add(qty.ToString());
                item.SubItems.Add(price.ToString("C")); // format as currency
                item.SubItems.Add(amount.ToString("C")); // format as currency
                listViewImpDetail.Items.Add(item);
            */

            // Method 2
            string[] row =
            {
                proId.ToString(),
                proName,
                qty.ToString(),
                price.ToString("C"), // format as currency
                amount.ToString("C") 
            };
            ListViewItem item = new ListViewItem(row);
            listViewImpDetail.Items.Add(item);


            try
            {
                cmd = new SqlCommand("spSetImpDetail", op.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@impDate", impDate);
                cmd.Parameters.AddWithValue("@staffId", staffId);
                cmd.Parameters.AddWithValue("@staffName", staffName);
                cmd.Parameters.AddWithValue("@supId", supId);
                cmd.Parameters.AddWithValue("@supName", supName);
                cmd.Parameters.AddWithValue("@proCode", proId);
                cmd.Parameters.AddWithValue("@proName", proName);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.ExecuteNonQuery();


                // clear input fields after added
                txtProID.Clear();
                txtPro.Clear();
                txtQty.Clear();
                txtInStockPrice.Clear();
                txtProID.Focus();
                txtQty.Focus();
                txtInStockPrice.Focus();

                MessageBox.Show("Success");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


 
        }
    }
}
