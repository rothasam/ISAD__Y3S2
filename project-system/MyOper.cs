using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace project_system
{
    public class MyOper
    {
        public SqlConnection con; // object of class SqlConnection for connect to db
        public void myConnection()
        {
            string str = "Data Source=LAPTOP-0LTH5V9D\\MSSQLSERVER2022; Initial Catalog=db_M7Y325; Integrated Security=true;";
            SqlDependency.Stop(str);
            SqlDependency.Start(str);
            con = new SqlConnection(str);
            con.Open();
        }

        public static void StyleButton(
            Button btn,
            Color? backColor = null,
            Color? hoverColor = null,
            Color? foreColor = null,
            Font font = null
)
        {
            Color normal = backColor ?? Color.FromArgb(52, 152, 219);   // Default blue
            Color hover = hoverColor ?? Color.FromArgb(41, 128, 185);   // Hover blue
            Color textColor = foreColor ?? Color.White;
            Font useFont = font ?? new Font("Noto Sans Khmer", 12, FontStyle.Bold);

            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = normal;
            btn.ForeColor = textColor;
            btn.Height = 35;
            //btn.Width = 140;
            btn.AutoSize = true;        // auto size width based on content
            btn.Padding = new Padding(6, 0, 6, 0);  // left and right padding
            btn.Font = useFont;
            btn.Cursor = Cursors.Hand;

            // Just add event handlers (don't try to remove previous ones)
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }


        public static void StyleInputBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10);
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
        }
    }
}

