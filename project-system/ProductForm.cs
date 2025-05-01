using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  // Classes for SQL Server database operations.

namespace project_system
{
    public partial class ProductForm : Form
    {
        MyOper op = new MyOper();  // create object of class MyOper to manage database connection
        SqlCommand com;  // for executing SQL commands
        SqlDataAdapter dap; // for filling data into DataTable
        DataTable dt;  // to hold data that retrieved from database

        public ProductForm()
        {
            op.myConnection(); // call method myConnection() from class MyOper to eastablish or create connection to database
            InitializeComponent(); 
            loadData(); // call method loadData()
        }

        public void loadData()
        {
            this.dgvPro.DefaultCellStyle.Font = new Font("Noto Sans Khmer", 10);
            this.dgvPro.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans Khmer", 10, FontStyle.Bold);
            dgvPro.DataSource = null;  // reset datasource to null to make sure the datagridview is empty before filling it with new data


            com = new SqlCommand("spGetProducts", op.con); // create object to execute stored procedure using connection from op.con
            com.CommandType = CommandType.StoredProcedure;
            //Prepares a SQL command to execute the stored procedure spGetProducts using the database connection op.con.


            SqlDependency dep = new SqlDependency(com);
            dep.OnChange += new OnChangeEventHandler(onChange); // This attaches the onChange method to the event handler of the SqlDependency.
            //Sets up SQL Dependency so that if the result of spGetProducts changes (e.g., data is inserted/updated/deleted), the onChange method will be triggered.
            //This allows your UI to auto-refresh.


            SqlDataAdapter depp = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            depp.Fill(dt);
            dgvPro.DataSource = dt;
            //Executes the command, fills a DataTable with the result, and binds it to the DataGridView.
        }

        // Responding to DB Changes or real-time data update
        // The method is triggered automatically by the SqlDependency
        public void onChange(Object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired) //r efers to the current form
            {
                dgvPro.BeginInvoke(new MethodInvoker(loadData));
                /*
                    InvokeRequired checks:
                    👉 true if the current code is running on a background thread (like from a SQL notification).
                    👉 false if it's running on the UI thread (safe to update UI components).
                    This is a safety check to prevent cross-thread UI access, which would otherwise crash the app.
                 */
            }
            else
            {
                loadData();
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
