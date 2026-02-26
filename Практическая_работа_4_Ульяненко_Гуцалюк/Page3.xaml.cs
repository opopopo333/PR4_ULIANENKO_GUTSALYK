using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Практическая_работа_4_Ульяненко_Гуцалюк
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            // Настройка графика
            ChartFunction.ChartAreas.Add(new ChartArea("Main"));
            ChartFunction.Series.Add(new Series("f(x)")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = false
            });
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbX0.Text, out double x0) &&
                double.TryParse(tbXk.Text, out double xk) &&
                double.TryParse(tbDx.Text, out double dx) &&
                double.TryParse(tbB.Text, out double b))
            {
                if (dx <= 0 && x0 < xk)
                {
                    MessageBox.Show("Шаг dx должен быть больше нуля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                tbResult.Clear();
                var series = ChartFunction.Series["f(x)"];
                series.Points.Clear();

                for (double x = x0; x <= xk; x = Math.Round(x + dx, 10))
                {
                    double arg = x + b - 0.0084;
                    if (arg < 0) continue;

                    double y = x * Math.Sin(Math.Sqrt(arg));
                    tbResult.AppendText($"x = {x:F3}   y = {y:F5}\n");
                    series.Points.AddXY(x, y);
                }
            }
            else
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbX0.Clear();
            tbXk.Clear();
            tbDx.Clear();
            tbB.Clear();
            tbResult.Clear();
            ChartFunction.Series["f(x)"].Points.Clear(); // очистка графика
        }
    }
}
