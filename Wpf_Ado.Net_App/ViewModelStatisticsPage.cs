using Wpf_Ado.Net_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Wpf_Ado.Net_App
{
    internal class ViewModelStatisticsPage : VeiwModelBase
    {
        protected DataView Items;

        private Command command;
        private DataGrid dataGrid;

        //RadioButton[] parametrs;

        ECount count;
        ESort sort;


        public ViewModelStatisticsPage(DataGrid dataGrid/*, RadioButton[] parametrs*/)
        {
            //this.parametrs = parametrs;
            this.dataGrid = dataGrid;
            command = new Command(PropertySelectAsync);
        }

        public ICommand GetCommand { get { return command; } }

        public DataGrid DataGrid { get => dataGrid; set { dataGrid = value; OnPropertyChanged("DataGrid"); } }

        private void PropertySelectAsync(object property)
        {
            //System.Windows.Forms.MessageBox.Show(property.ToString());
            if (property is ECount)
                count = (ECount)property;
            else if (property is ESort)
                sort = (ESort)property;

            switch (sort)
            {
                case ESort.day:
                    {
                        if (count==ECount.enter)
                        {
                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName FROM dbo.Log WHERE Time > DATEADD(DAY, -1, GETDATE())  GROUP BY UserName");
                        }
                        else if (count==ECount.workTime)
                        {
                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName,
                                            SUM(WorkTime) AS WorkTime FROM dbo.Log AS l 
                                            INNER JOIN dbo.WorkTime AS wt 
                                            ON l.Id=wt.LogId  
                                            WHERE Time > DATEADD(DAY, -1, GETDATE())
                                            GROUP BY UserName");
                        }
                    }
                    break;
                case ESort.week:
                    {
                        if (count == ECount.enter)
                        {
                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName FROM dbo.Log WHERE Time > DATEADD(WEEK, -1, GETDATE()) GROUP BY UserName");
                        }
                        else if (count == ECount.workTime)
                        {

                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName,
                                            SUM(WorkTime) AS WorkTime FROM dbo.Log AS l 
                                            INNER JOIN dbo.WorkTime AS wt 
                                            ON l.Id=wt.LogId  
                                            WHERE Time > DATEADD(WEEK, -1, GETDATE())
                                            GROUP BY UserName");
                        }
                    }
                    break;
                case ESort.month:
                    {
                        if (count == ECount.enter)
                        {
                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName FROM dbo.Log WHERE Time > DATEADD(MONTH, -3000, GETDATE()) GROUP BY UserName");//TODO много месяцев убрать
                        }
                        else if (count == ECount.workTime)
                        {
                            ReloadAsync(@"SELECT COUNT(UserName) AS Count, UserName,
                                            SUM(WorkTime) AS WorkTime FROM dbo.Log AS l 
                                            INNER JOIN dbo.WorkTime AS wt 
                                            ON l.Id=wt.LogId  
                                            WHERE Time > DATEADD(MONTH, -1, GETDATE())
                                            GROUP BY UserName");
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        protected async void ReloadAsync(string CommandText = "SELECT * FROM dbo.Log")
        {
            try
            {
                Items = await GetItemsAsync(CommandText: CommandText);
                DataGrid.ItemsSource = Items;
                //dataGrid.ItemsSource = Items;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public Task<DataView> GetItemsAsync(string sConnectionString = @"server=DESKTOP-E6UPCJ7\MSSQLSERVER01;database=test;integrated Security=SSPI;", string CommandText = "SELECT * FROM dbo.Log")
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
                    cmd.CommandText = CommandText;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    // Thread.Sleep(5000);
                }
                return ds.Tables[0].DefaultView;
            }
            );
        }

    }
}