using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    /// 
    public class Swan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Swan(string id, string Names, string BLOW)
        {
            Id = id;
            Name = Names;
            LastName = BLOW;
        }
    }


    public partial class Page1 : Page
    {
        public Thread Thrd;
       

        public Page1()
        {
            InitializeComponent();

          
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void Button_Click_2(object sender, EventArgs e)
        {
            one.Visibility = Visibility.Hidden;
            two.Visibility = Visibility.Hidden;
            four.Visibility = Visibility.Hidden;
            Button btn = sender as Button;
            MessageBox.Show("произошёл выход");
            


            btn.Content = "ВОЙТИ";
            btn.Click -= new RoutedEventHandler(Button_Click_2);
            btn.Click += new RoutedEventHandler(Button_Click_2_1);
        }

        private void Button_Click_2_1(object sender, EventArgs e)
        {
            one.Visibility = Visibility.Visible;
            two.Visibility = Visibility.Visible;
            four.Visibility = Visibility.Visible;
            Button btn = sender as Button;
            btn.Content = "Выйти";
            MessageBox.Show("приложение снова активно");
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var connector = new Cleverence.Warehouse.StorageConnector();
            connector.SelectCurrentApp("http://192.168.1.2:10501/373139b9-8245-4202-938e-c54667e2abfa");
            var tableContractor = connector.GetTableAccessor("файл");
            try
            {
                tableContractor.BeginUpload(true);
                var rows = new Cleverence.Warehouse.RowCollection();
                List<Swan> list = new List<Swan>();
                using (StreamReader sr = new StreamReader(@"D:\smartmobile\WpfApp1\WpfApp1\bin\Debug\1.csv", true))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parsed = line.Split(' ');
                        string id = parsed[0];
                        string name = parsed[1];
                        string inn = parsed[2];
                        
                        if(rows.Count>=1)
                        {
                            tableContractor.Upload(rows);
                            rows = new Cleverence.Warehouse.RowCollection();
                        }
                        var row = new Cleverence.Warehouse.Row();
                        row.SetField("ид",id);
                        row.SetField("наименование",name);
                        row.SetField("ин",inn);

                        rows.Add(row);
                    }
                    if(rows.Count>0)
                    {
                        tableContractor.Upload(rows);
                    }
                }
                tableContractor.EndUpload();


            }
            catch
            {
                tableContractor.ResetUpload();
            }
            
            Environment.Exit(0);
        }
    }
}
