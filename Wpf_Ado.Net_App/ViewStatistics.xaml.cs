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
using System.Data;
using System.Data.SqlClient;

namespace Wpf_Ado.Net_App
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class ViewStatisticsPage : Page
    {
        static ViewModelStatisticsPage viewModelStatisticsPage;
        static ViewStatisticsPage()
        {
           viewModelStatisticsPage = new ViewModelStatisticsPage();
        }
        public ViewStatisticsPage()
        {
            InitializeComponent();
            DataContext = viewModelStatisticsPage;
            ReloadAsync();
        }


        protected DataView Items;

        protected async void ReloadAsync()
        {
            try
            {
                Items = await GetItemsAsync();
                dataGrid.ItemsSource = Items;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public Task<DataView> GetItemsAsync(string sConnectionString = @"server=DESKTOP-E6UPCJ7\SQLEXPRESS;database=test;integrated Security=SSPI;")
        {
            //HOME//DESKTOP-E6UPCJ7\MSSQLSERVER01
            //STEP//DESKTOP-PC73D7E\SQLEXPRESS
            return Task.Run(() =>
            {
                DataSet ds = new DataSet("MyDataSet");

                using (SqlConnection conn = new SqlConnection(sConnectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Log";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    //  Thread.Sleep(3000);
                }
                return ds.Tables[0].DefaultView;
            }
            );
        }
    }
}
