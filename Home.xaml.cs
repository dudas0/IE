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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            FillListView();
        }

        private void FillListView()
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = MA; Integrated Security = True;");
            using SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand("Select Title, Director, Year, Genre, AvgRate, NumOfRates  from movies", con)
            };
            DataTable dt = new DataTable("movies");
            adapter.Fill(dt);
            lista.ItemsSource = dt.DefaultView;
        }

        private void wyszukaj_Click(object sender, RoutedEventArgs e)
        {
            lista.Visibility = Visibility.Visible;
            wyszukaj.Visibility = Visibility.Hidden;
        }

        /*private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem o = ((sender as ListView).SelectedItem as ListViewItem);
            title.Visibility = Visibility.Visible;
            title.Content = o.Content.ToString();
        }*/
    }
}
