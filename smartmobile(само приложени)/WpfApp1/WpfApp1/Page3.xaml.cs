using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    /// 
    public class Sweet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Sweet(string id, string Names,string BLOW)
        {
            Id = id;
            Name = Names;
            LastName = BLOW;
        }
    }



    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            List<Sweet> list = new List<Sweet>();
            using (StreamReader sr = new StreamReader(@"D:\smartmobile\WpfApp1\WpfApp1\bin\Debug\1.csv", true))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parsed = line.Split(' ');
                    list.Add(new Sweet(parsed[0],parsed[1],parsed[2]));
                }
            }
            gridsweet.ItemsSource = list;

        }
    }
}
