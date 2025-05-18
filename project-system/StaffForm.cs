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
using System.IO;

namespace project_system
{
    public partial class StaffForm : Form
    {
        MyOper op = new MyOper();
        SqlCommand com; // read data from store procedure
        SqlDataAdapter dap; // also read data
        DataTable dt; // add data to datagridview
        string filePath;
        Byte[] photo; // to store image in byte array, because in this client we use byte array to store image and in database we use varbinary(max) to store image


        public StaffForm()
        {
            op.myConnection();
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {

            this.dgvStaff.DefaultCellStyle.Font = new Font("Noto Sans Khmer", 10);
            this.dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans Khmer", 10, FontStyle.Bold);

            dgvStaff.DataSource = null;
            com = new SqlCommand("spGetStaffs", op.con);
            com.CommandType = CommandType.StoredProcedure;
 
            SqlDependency dep = new SqlDependency(com);
            dep.OnChange += new OnChangeEventHandler(onChange);

            SqlDataAdapter depp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            depp.Fill(dt);
            dgvStaff.DataSource = dt;


            dgvStaff.Columns[0].HeaderText = "អត្ថលេខ";
            dgvStaff.Columns[1].HeaderText = "ឈ្មោះ";
            dgvStaff.Columns[2].HeaderText = "ភេទ";
            dgvStaff.Columns[3].HeaderText = "ថ្ងៃខែឆ្នាំកំណើត";
            dgvStaff.Columns[4].HeaderText = "មុខតំណែង";
            dgvStaff.Columns[5].HeaderText = "ប្រាក់ខែ";
            dgvStaff.Columns[6].HeaderText = "ឈប់ធ្វើការ";
            dgvStaff.Columns[7].HeaderText = "រូបភាព";

            dgvStaff.RowTemplate.Height = 80; // set height of row 
            dgvStaff.Columns[7].Width = 75; // set width of column


            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dgvStaff.Columns["Photo"];  // photo is the column name in db
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch; // stretch image to fit the cell

            /*
             in sql server when using service brokder we cannot use * to select data but its real column name. 
            => go to sql and right click on file store procedure then click modify. Next change * and add columns name , add 'dbo.tableName' 
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

        private void onSearch(object sender, EventArgs e)
        {
            (dgvStaff.DataSource as DataTable).DefaultView.RowFilter = string.Format(
                "Name LIKE '%{0}%' OR CONVERT(StaffID, 'System.String') LIKE '%{0}%'", txtSearch.Text);   // search with '%{0}%' for varchar and N'%{0}%' for nvarchar
        }                        // convert StaffID to string because it is integer in database and we want to search with string

        private void btnBrowseFile(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JPEG FILE| *.jpg; *.jpeg|PNG FILE|*.png";
            fd.Title = "Open an image...";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filePath = fd.FileName;
                picBox.Image = Image.FromFile(filePath);
            }
        }
        private void onAddNew(object sender, EventArgs e)
        {
            var salary = Decimal.Parse(txtSalary.Text, NumberStyles.Currency); // because salary is money type in database
            com = new SqlCommand("spSetStaff", op.con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@fn",txtName.Text);

            if(rdbFemale.Checked == true)
                com.Parameters.AddWithValue("@gender", "ស្រី");
            else
                com.Parameters.AddWithValue("@gender", "ប្រុស");

            com.Parameters.AddWithValue("@dob",dateDob.Value);
            com.Parameters.AddWithValue("@position", txtPosition.Text);
            com.Parameters.AddWithValue("@salary", salary);
            com.Parameters.AddWithValue("@stopwork",0); // 0 mean not stop work and 1 mean stop work

            if (filePath != null)
                photo = File.ReadAllBytes(filePath);
            com.Parameters.AddWithValue("@photo", photo);

            com.ExecuteNonQuery();  // run stored procedure
            MessageBox.Show("ជោគជ័យ");
            filePath = null;

        }

        // this method is used to update data base on cell click 
        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if(dgvStaff.RowCount > 0) // RowCount is the property to count data in datagridview
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvStaff.Rows[i];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "ស្រី")
                    rdbFemale.Checked = true;
                else
                    rdbMale.Checked = true;
                dateDob.CustomFormat = "yyyy-MM-dd";
                txtPosition.Text = row.Cells[4].Value.ToString();
                txtSalary.Text = string.Format("{0:c}", row.Cells[5].Value); // letter there is the currency

                // read byte from datagridview

                if(row.Cells[7].Value != DBNull.Value)
                {
                    photo = (byte[])row.Cells[7].Value;
                    MemoryStream ms = new MemoryStream(photo); 
                    picBox.Image = Image.FromStream(ms);  // check image format if it not match the type that required ?
                }
                else
                {
                    MessageBox.Show("No image");
                }

            }

        }

        private void onDelete(object sender, EventArgs e)
        {
            com = new SqlCommand("spDeleteStaff", op.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.ExecuteNonQuery();
        }

        private void onUpdate(object sender, EventArgs e)
        {
            var salary = Decimal.Parse(txtSalary.Text, NumberStyles.Currency); // because salary is money type in database
            com = new SqlCommand("spUpdateStaff", op.con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtId.Text);
            com.Parameters.AddWithValue("@fn", txtName.Text);

            if (rdbFemale.Checked == true)
                com.Parameters.AddWithValue("@gen", "ស្រី"); 
            else
                com.Parameters.AddWithValue("@gen", "ប្រុស");

            com.Parameters.AddWithValue("@dob", dateDob.Value);
            com.Parameters.AddWithValue("@pos", txtPosition.Text);
            com.Parameters.AddWithValue("@sal", salary);
            com.Parameters.AddWithValue("@stopwork", 0); // 0 mean not stop work and 1 mean stop work

            if (filePath != null)
                photo = File.ReadAllBytes(filePath);
            com.Parameters.AddWithValue("@photo", photo);

            com.ExecuteNonQuery();  // run stored procedure
            MessageBox.Show("ជោគជ័យ");
            filePath = null;
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

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
