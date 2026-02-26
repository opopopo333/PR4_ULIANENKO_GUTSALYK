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

namespace Практическая_работа_4_Ульяненко_Гуцалюк
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

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbX.Text);
            double q = double.Parse(tbQ.Text);

            double fx = 0;

            if (rbSh.IsChecked == true)
                fx = Math.Sinh(x);
            else if (rbX2.IsChecked == true)
                fx = Math.Pow(x, 2);
            else if (rbExp.IsChecked == true)
                fx = Math.Exp(x);
            else
            {
                MessageBox.Show("Выберите функцию f(x)");
                return;
            }

            double absXq = Math.Abs(x * q);
            double k;

            if (absXq > 10)
                k = Math.Log(Math.Abs(fx) + Math.Abs(q));
            else if (absXq < 10)
                k = Math.Exp(fx + q);
            else
                k = fx + q;

            tbResult.Text = k.ToString();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX.Clear();
            tbQ.Clear();
            tbResult.Clear();

            rbSh.IsChecked = false;
            rbX2.IsChecked = false;
            rbExp.IsChecked = false;
        }
    }
}
