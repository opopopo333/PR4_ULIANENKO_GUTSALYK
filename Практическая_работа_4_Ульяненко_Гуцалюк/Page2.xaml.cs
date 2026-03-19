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
using MessageBox = System.Windows.MessageBox;

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

        public void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(tbX.Text, out double x) || !double.TryParse(tbQ.Text, out double q))
            {
                MessageBox.Show("Пожалуйста, введите числовые значения для X и Q!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double fx;
            if (rbSh.IsChecked == true)
                fx = Math.Sinh(x);
            else if (rbX2.IsChecked == true)
                fx = Math.Pow(x, 2);
            else if (rbExp.IsChecked == true)
                fx = Math.Exp(x);
            else
            {
                MessageBox.Show("Выберите функцию f(x)!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            double absXq = Math.Abs(x * q);
            double k;

            if (absXq > 10)
            {
                double logArg = Math.Abs(fx) + Math.Abs(q);
                if (logArg <= 0)
                {
                    MessageBox.Show("Ошибка: Аргумент логарифма должен быть больше нуля.", "Математическая ошибка");
                    return;
                }
                k = Math.Log(logArg);
            }
            else if (absXq < 10)
            {
                k = Math.Exp(fx + q);
            }
            else 
            {
                k = fx + q;
            }

            tbResult.Text = Math.Round(k, 6).ToString();
        }

        public void BtnClear_Click(object sender, RoutedEventArgs e)
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
