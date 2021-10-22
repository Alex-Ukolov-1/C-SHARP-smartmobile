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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void THREE_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            const string message = "ВЫ ХОТИТЕ СОХРАНИТЬ ФАЙЛ?!";
            const string caption = "Форма сохранения";

            var result = MessageBox.Show(message, caption,
               MessageBoxButton.YesNo, MessageBoxImage.Warning);
            string sourcePath = @"D:\smartmobile\WpfApp1\WpfApp1\bin\Debug";
            string targetPath = @"D:\smartmobile\WpfApp1";

            string text = String.Format(ONE.Text);
            try
            {
                Convert.ToString(ONE.Text);
            }

            catch
            {
                MessageBox.Show("не получилось вставить строку");
            }
            string textt = String.Format(TWO.Text);
            try
            {
                Convert.ToInt32(TWO.Text);
            }

            catch
            {
                MessageBox.Show("не получилось конвертировать ......");
            }

            string texttt = String.Format(THREE.Text);
            string b = " " + String.Format(text) + " " + String.Format(textt) + " " + String.Format(texttt);
            string[] st = new string[] { b };

            foreach (var node in st)
            {
                File.AppendAllText("1.csv", node + "\n", Encoding.GetEncoding(1251));
            }
        }
    }
}
