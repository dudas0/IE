using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fname.Text == "" || lname.Text == "")
                MessageBox.Show("PROSZĘ WYPEŁNIJ WSZYSTKIE POLA'!");
            else if (password.Password != password2.Password)
                MessageBox.Show("Podane hasła różnią się!");

            else
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;"))
                {
                    conn.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddUser", conn);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FName", fname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LName", lname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", email.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Nick", login.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", password.Password.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("ZAREJESTROWAŁEŚ SIĘ!");
                    this.Hide();
                    new MainWindow().Show();
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().Show();
        }
    }
}
