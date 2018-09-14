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


namespace Wpf_Ado.Net_App
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            DataGrid.ItemsSource = GridData;
          
        }

        public DataView GridData
        {
            get
            {
                DataSet ds = new DataSet("MyDataSet");
                

                using (SqlConnection conn = new SqlConnection (@"server=DESKTOP-PC73D7E\SQLEXPRESS;database=test;integrated Security=SSPI;"))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM dbo.Log";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                
                return ds.Tables[0].DefaultView;
            }
        }
        


       
    }

    
}
