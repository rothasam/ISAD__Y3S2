﻿using System;
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
        private MainForm mainForm;
        public CustomerForm(MainForm mainForm)
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

        private void clearInput()
        {
            txtName.Text = null;
            txtId.Text = null;
            txtContact.Text = null;

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

            dgvCus.Columns[0].HeaderText = "អត្ថលេខ";
            dgvCus.Columns[1].HeaderText = "ឈ្មោះ";
            dgvCus.Columns[2].HeaderText = "លេខទំនាក់ទំនង";
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

        private void onAddNew(object sender, EventArgs e)
        {
            com = new SqlCommand("spSetCustomer", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@contact", txtContact.Text);

            com.ExecuteNonQuery();  // run stored procedure
            MessageBox.Show("ជោគជ័យ");
            clearInput();
        }

        private void onSearch(object sender, EventArgs e)
        {
            (dgvCus.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                "Name LIKE '%{0}%'", txtSearch.Text);
        }

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if(dgvCus.RowCount > 0)
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvCus.Rows[i];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = dgvCus.Rows[i].Cells[1].Value.ToString();
                txtContact.Text = dgvCus.Rows[i].Cells[2].Value.ToString();


                    
            }

        }

        private void onDelete(object sender, EventArgs e)
        {
            com = new SqlCommand("spDeleteCustomer", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.ExecuteNonQuery();

            clearInput();
        }

        private void onUpdate(object sender, EventArgs e)
        {
            com = new SqlCommand("spUpdateCustomer", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@contact", txtContact.Text);

            com.ExecuteNonQuery();

            MessageBox.Show("ជោគជ័យ");

            clearInput();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }
    }
}
