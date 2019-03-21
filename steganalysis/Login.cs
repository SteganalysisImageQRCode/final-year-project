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
namespace imgefile
{
     public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@" Data Source=.\SQLEXPRESS;Initial Catalog=filemrg;Integrated Security=True;MultipleActiveResultSets=True");

        public Login()
        {
            InitializeComponent();
            menuStrip1.Visible = false;
        }

        private void Log_bt_Click(object sender, EventArgs e)
        {
            if (user_id_tx.Text=="admin" && pw_tx.Text=="123")
            {
                menuStrip1.Visible = true;
                Encryption frm = new Encryption();
                frm.Show();
            }

            else
            {
                menuStrip1.Visible = false;
                MessageBox.Show("Invalid password or user id");
            }
            /*
            con.Open();
            string sql_get1 = "select * from useraccount where userid=@userid and password=@password";
            SqlCommand cmd_get1 = new SqlCommand(sql_get1, con);
            cmd_get1.Parameters.AddWithValue("@userid",user_id_tx.Text);
            cmd_get1.Parameters.AddWithValue("@password",pw_tx.Text);
            SqlDataReader rd1 = cmd_get1.ExecuteReader();
            if (rd1.Read())
            {
                menuStrip1.Visible = true;
                Encryption frm = new Encryption();
                frm.Show();
            }
        
            else
            {
                menuStrip1.Visible = false;
              
                MessageBox.Show("Invalide password or user id");
            }
            rd1.Dispose();
            rd1.Close();
            con.Close();
            */
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void endripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encryption frm = new Encryption();
            frm.Show();
        } 

        private void toDecryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            q2 frm = new q2();
            frm.Show();
        }

        private void imageCloudOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cloudsharing frm = new Cloudsharing();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pw_tx_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
