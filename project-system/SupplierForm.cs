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
        private MainForm mainForm;

        public SupplierForm(MainForm mainForm)
        {
            op.myConnection();
            InitializeComponent();
            loadData();
            this.mainForm = mainForm;

            MyOper.StyleButton(btnAdd, backColor: Color.FromArgb(52, 152, 219), hoverColor: Color.FromArgb(40, 116, 167));
            MyOper.StyleButton(btnExit, backColor: Color.White, hoverColor: Color.Gray, foreColor: Color.Black);
            MyOper.StyleButton(btnEdit, backColor: Color.Orange, hoverColor: Color.DarkOrange);
            MyOper.StyleButton(btnDelete, backColor: Color.Red, hoverColor: Color.DarkRed);
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

        private void onDelete(object sender, EventArgs e)
        {
            // 
        }

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if(dgvSup.Rows.Count > 0)
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvSup.Rows[i];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtContact.Text = row.Cells[3].Value.ToString();
            }
        }


        private void onUpdate(object sender, EventArgs e)
        {
            com = new SqlCommand("spUpdateSupplier", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@address", txtAddress.Text);
            com.Parameters.AddWithValue("@contact", txtContact.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Supplier updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }
    }
}
