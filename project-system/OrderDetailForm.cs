using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_system
{
    public partial class OrderDetailForm : Form
    {
        MyOper op = new MyOper();
        private MainForm mainForm;
        SqlCommand cmd;
        Decimal Total = 0;
        public OrderDetailForm(MainForm mainForm)
        {
            op.myConnection();
            InitializeComponent();
            this.mainForm = mainForm;

            MyOper.StyleButton(btnAdd, backColor: Color.FromArgb(52, 152, 219), hoverColor: Color.FromArgb(40, 116, 167));
            MyOper.StyleButton(btnExit, backColor: Color.White, hoverColor: Color.Gray, foreColor: Color.Black);
            MyOper.StyleButton(btnRemove, backColor: Color.Red);
            MyOper.StyleButton(btnSave, backColor: Color.Green);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Decimal amount, s;

            ListViewItem lv = lsvImpDetail.FindItemWithText(txtProID.Text);  // store on the old value
            if (lv != null) // that item is exist in the listview
            {
                var qty = int.Parse(lv.SubItems[2].Text) + int.Parse(txtQty.Text); // calculate to find new quantity
                lv.SubItems[2].Text = qty.ToString();
                Total = Total - decimal.Parse(lv.SubItems[4].Text, NumberStyles.Currency);
                var price = decimal.Parse(txtInStockPrice.Text, NumberStyles.Currency);
                amount = qty * price;
                //lv.SubItems[4].Text = price.ToString("C");
                lv.SubItems[4].Text = string.Format("{0:c}", amount);
                Total += amount;
            }
            else
            {
                ListViewItem item;
                string[] arr = new string[5];
                arr[0] = txtProID.Text;
                arr[1] = txtPro.Text;
                arr[2] = txtQty.Text;
                //arr[3] = decimal.Parse(txtInStockPrice.Text).ToString("C"); // format as currency
                s = decimal.Parse(txtInStockPrice.Text);
                //s = decimal.Parse(txtInStockPrice.Text, NumberStyles.Currency);
                arr[3] = string.Format("{0:C}", s); // format as currency
                amount = decimal.Parse(txtQty.Text) * decimal.Parse(txtInStockPrice.Text); // calculate amount
                //int qty;
                //if (!int.TryParse(txtQty.Text, out qty))
                //{
                //    MessageBox.Show("Please enter a valid quantity.");
                //    txtQty.Focus();
                //    return;
                //}

                //decimal price;
                //if (!decimal.TryParse(txtInStockPrice.Text, out price))
                //{
                //    MessageBox.Show("Please enter a valid price.");
                //    txtInStockPrice.Focus();
                //    return;
                //}

                // amount = qty * price;
                arr[4] = string.Format("{0:C}", amount);

                item = new ListViewItem(arr);
                lsvImpDetail.Items.Add(item);
                Total += amount;
            }

            txtTotal.Text = string.Format("{0:c}", Total);
            txtProID.Text = null;
            txtPro.Text = null;
            txtQty.Text = null;
            txtInStockPrice.Text = null;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dResult;
            foreach (ListViewItem item in lsvImpDetail.SelectedItems)
            {
                if (item.Selected)
                {
                    dResult = MessageBox.Show("Are you sure do you want to remove item ?",
                        "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        ListViewItem lv = lsvImpDetail.SelectedItems[0];
                        lsvImpDetail.Items.Remove(lv);
                        var a = Decimal.Parse(lv.SubItems[4].Text, NumberStyles.Currency);
                        Total -= a;
                        txtTotal.Text = string.Format("{0:c}", Total);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataTable dt;
            da = new SqlDataAdapter("SELECT * FROM fnGetStaffs()", op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = null;
            cboStaffID.Items.Clear();
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID"; 
            cboStaffID.ValueMember = "FullName"; 
            cboStaffID.Text = null;


            da = new SqlDataAdapter("SELECT * FROM fnGetCustomers()", op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboCusID.DataSource = null;
            cboCusID.Items.Clear();
            cboCusID.DataSource = dt;
            cboCusID.DisplayMember = "cusID";
            cboCusID.ValueMember = "CusName";
            cboCusID.Text = null;


            lsvImpDetail.Clear();
            lsvImpDetail.View = View.Details;
            lsvImpDetail.Columns.Add("Pro ID", 100);
            lsvImpDetail.Columns.Add("Name", 200);
            lsvImpDetail.Columns.Add("Qty", 100);
            lsvImpDetail.Columns.Add("Price", 100);
            lsvImpDetail.Columns.Add("Amount", 100);
        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string fullName = cboStaffID.SelectedValue.ToString();
            txtStaffName.Text = fullName;
        }

        private void cboCusID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string cusName = cboCusID.SelectedValue.ToString();
            txtCusName.Text = cusName;
        }

        private void txtProID_TextChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("spGetProName", op.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@proCode", txtProID.Text);
            var dr = cmd.ExecuteReader();

            //txtPro.Text = dr.Read() ? dr.GetString(0) : null;
            //txtInStockPrice.Text = dr.Read() ? dr.GetString(1) : null;

            if (dr.Read())
            {
                txtPro.Text = dr.GetString(0);
                txtInStockPrice.Text = dr.GetDecimal(1).ToString();
            }
            else
            {
                txtPro.Text = null;
                txtInStockPrice.Text = null;
            }

            dr.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtMaster = new DataTable();
            dtMaster.Columns.Add("ImpDate", typeof(string));
            dtMaster.Columns.Add("staffId", typeof(int));
            dtMaster.Columns.Add("StaffName", typeof(string));
            dtMaster.Columns.Add("cusId", typeof(int));
            dtMaster.Columns.Add("CusName", typeof(string));
            dtMaster.Columns.Add("Total", typeof(float));

            string impDate = dtpImpDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            dtMaster.Rows.Add(DateTime.Parse(impDate), cboStaffID.Text, txtStaffName.Text,
                cboCusID.Text, txtCusName.Text, Total);


            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ProCode", typeof(string));
            dtDetail.Columns.Add("ProName", typeof(string));
            dtDetail.Columns.Add("Qty", typeof(int));
            dtDetail.Columns.Add("Price", typeof(float));
            dtDetail.Columns.Add("Amount", typeof(float));

            foreach (ListViewItem item in lsvImpDetail.Items)
            {
                string pid = item.Text;  // or item.SubItems[0].Text;
                string pn = item.SubItems[1].Text;
                int q = int.Parse(item.SubItems[2].Text);
                var p = decimal.Parse(item.SubItems[3].Text, NumberStyles.Currency);
                var a = decimal.Parse(item.SubItems[4].Text, NumberStyles.Currency);
                dtDetail.Rows.Add(pid, pn, q, p, a);
            }
             

            cmd = new SqlCommand("spSetOrderDetail", op.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@OM";
            par1.SqlDbType = SqlDbType.Structured;
            par1.Value = dtMaster;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "@OD";
            par2.SqlDbType = SqlDbType.Structured;
            par2.Value = dtDetail;
            cmd.Parameters.Add(par2);

            cmd.ExecuteNonQuery();

            MessageBox.Show("saved successfully!");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
