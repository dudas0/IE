using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }



        private void Log_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            con.Open();
            using SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tableUser WHERE Nick='" + login.Text + "' AND Password='" + password.Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Close();
                new Home().Show();
            }
            else
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło");

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().Show();
        }
    }
}
