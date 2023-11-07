using System.Data.SqlClient;
using System.Data; 

namespace LoginForm
{
    public partial class frm_login1 : Form
    {
        SqlConnection con; 
        public frm_login1()
        {
            InitializeComponent();
        }

        private void frm_login_Load1(object sender, EventArgs e)
        {
        
            
        }

        private void btn_login_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PRASEGR;Initial Catalog=login_form;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM login WHERE user_name = @username AND password =@pass", con);

            cmd.Parameters.AddWithValue("username", txt_user.Text);
            cmd.Parameters.AddWithValue("pass", txt_password.Text);
            con.Open();
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {

                    frm_menu menu = new frm_menu();
                    menu.Show();
                    this.Hide();

                }
                else
                {
                    txt_password.Clear();
                    txt_password.Focus();
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally { 

            con.Close();
        }
        }

        private void btn_clear_Click1(object sender, EventArgs e)
        {
            txt_password.Clear(); 
            txt_user.Clear();

            txt_user.Focus();

        }

        private void btn_exit_Click1(object sender, EventArgs e)
        {
            DialogResult res;
            res= MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
               this.Show();  
               txt_user.Focus();
            }
            
        }

      
    }
}