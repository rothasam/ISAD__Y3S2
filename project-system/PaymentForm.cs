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
using System.Globalization;

namespace project_system
{
    public partial class PaymentForm : Form
    {
        MyOper op = new MyOper();
        private MainForm mainForm;
        DataTable dt;
        SqlCommand com;
        decimal t, d, r;
        public PaymentForm(MainForm mainForm)
        {
            op.myConnection();
            InitializeComponent();
            this.mainForm = mainForm;

            MyOper.StyleButton(btnAdd, backColor: Color.FromArgb(52, 152, 219), hoverColor: Color.FromArgb(40, 116, 167));
            MyOper.StyleButton(btnExit, backColor: Color.White, hoverColor: Color.Gray, foreColor: Color.Black);


        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            //DataTable dt;
            da = new SqlDataAdapter("SELECT * FROM fnGetStaffs()", op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = null;
            cboStaffID.Items.Clear();
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID"; 
            cboStaffID.ValueMember = "FullName"; 
            cboStaffID.Text = null;

            da = new SqlDataAdapter("SELECT * FROM dbo.fnGetInvoice()",op.con);
            dt = new DataTable();
            da.Fill(dt);
            cboInvCode.DataSource = null;
            cboInvCode.Items.Clear();
            cboInvCode.DataSource = dt;
            cboInvCode.DisplayMember = "OrdCode";
            cboInvCode.ValueMember = "OrdCode";
            cboInvCode.Text = null;


        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string fullName = cboStaffID.SelectedValue.ToString();
            txtStaffName.Text = fullName; 
        }

        private void cboInvCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            com = new SqlCommand("spGetPayment", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ic", cboInvCode.SelectedValue.ToString());
            var dr = com.ExecuteReader();
            if (dr.Read())
            {
                //txtTotal.Text = dr.GetDecimal(0).ToString("N2"); 
                txtTotal.Text = string.Format("{0:c}", Decimal.Parse(dr[0].ToString()));
                txtDeposit.Text = dr[1].ToString();
                if (string.IsNullOrEmpty(txtDeposit.Text))
                {
                    txtRemain.Text = txtTotal.Text;
                }
                else
                {
                    t = Decimal.Parse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    d = Decimal.Parse(txtDeposit.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    r = t - d;
                    txtRemain.Text = String.Format("{0:c}", Decimal.Parse(r.ToString()));
                    txtDeposit.ReadOnly = true;
                }
            }  
            dr.Dispose();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void txtDeposit_Leave(object sender, EventArgs e)
        {
            t = Decimal.Parse(txtTotal.Text, NumberStyles.Currency,CultureInfo.CurrentCulture.NumberFormat);
            d = Decimal.Parse(txtDeposit.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
            r = t-d;
            txtRemain.Text = String.Format("{0:c}",Decimal.Parse(r.ToString())); 
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    com = new SqlCommand("spPayment", op.con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@PD", dtp.Text);
        //    com.Parameters.AddWithValue("@SI", cboStaffID.Text);
        //    com.Parameters.AddWithValue("@FN", txtStaffName.Text);
        //    com.Parameters.AddWithValue("@IC", int.Parse(cboInvCode.SelectedValue.ToString()));
        //    if(d+r == t)
        //        com.Parameters.AddWithValue("@Dep", decimal.Parse(txtRemain.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));
        //    else
        //        com.Parameters.AddWithValue("@Dep", float.Parse(txtDeposit.Text));
        //    com.Parameters.AddWithValue("@A", decimal.Parse(txtTotal.Text,NumberStyles.Currency,CultureInfo.CurrentCulture.NumberFormat));
        //    com.ExecuteNonQuery();
        //    MessageBox.Show("ការទូទាត់បានបញ្ចប់ដោយជោគជ័យ", "ការទូទាត់", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            com = new SqlCommand("spPayment", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PD", dtp.Text);
            com.Parameters.AddWithValue("@SI", cboStaffID.Text);
            com.Parameters.AddWithValue("@FN", txtStaffName.Text);
            com.Parameters.AddWithValue("@IC", int.Parse(cboInvCode.SelectedValue.ToString()));

            // Always insert the current remaining balance
            com.Parameters.AddWithValue("@Dep", decimal.Parse(txtRemain.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));

            com.Parameters.AddWithValue("@A", decimal.Parse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));
            com.ExecuteNonQuery();

            MessageBox.Show("ការទូទាត់បានបញ្ចប់ដោយជោគជ័យ", "ការទូទាត់", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
