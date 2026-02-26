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
            double x0 = double.Parse(tbX0.Text);
            double xk = double.Parse(tbXk.Text);
            double dx = double.Parse(tbDx.Text);
            double b = double.Parse(tbB.Text);

            tbResult.Clear();
            var series = ChartFunction.Series["f(x)"];
            series.Points.Clear();

            for (double x = x0; x <= xk; x += dx)
            {
                double y = x * Math.Sin(Math.Sqrt(x + b - 0.0084));
                tbResult.AppendText($"x = {x:F3}   y = {y:F5}\n");

                series.Points.AddXY(x, y); // добавляем точку на график
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
