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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbX.Text);
            double y = double.Parse(tbY.Text);
            double z = double.Parse(tbZ.Text);

            double part1 = Math.Pow(2, -x);

            double part2 = Math.Sqrt(
                x + Math.Pow(Math.Abs(y), 0.25)
            );

            double part3 = Math.Pow(
                Math.Exp(x - 1 / Math.Sin(z)),
                1.0 / 3.0
            );

            double a = part1 * part2 * part3;

            tbResult.Text = a.ToString();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX.Clear();
            tbY.Clear();
            tbZ.Clear();
            tbResult.Clear();
        }
    }
}
