using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(4, res);
            Assert.AreNotEqual(5, res);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        /// <summary>
        /// Тест Page1 (проверка формулы)
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page1();

            page.tbX.Text = "1";
            page.tbY.Text = "4";
            page.tbZ.Text = "1";

            page.BtnCalc_Click(null, null);

            double actual = double.Parse(page.tbResult.Text);

            // считаем ожидаемое значение вручную
            double x = 1, y = 4, z = 1;

            double part1 = Math.Pow(2, -x);

            double part2 = Math.Sqrt(
                x + Math.Pow(Math.Abs(y), 0.25)
            );

            double part3 = Math.Pow(
                Math.Exp(x - 1 / Math.Sin(z)),
                1.0 / 3.0
            );

            double a = part1 * part2 * part3;
            double expected = Math.Round(a, 6);

            expected = Math.Round(expected, 6);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест Page2 (ветка exp)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page2();

            page.tbX.Text = "1";
            page.tbQ.Text = "2";
            page.rbExp.IsChecked = true;

            page.BtnCalc_Click(null, null);

            double actual = double.Parse(page.tbResult.Text);

            double x = 1, q = 2;

            double fx = Math.Exp(x);
            double expected = Math.Exp(fx + q); 

            expected = Math.Round(expected, 6);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест Page3 (первое значение цикла)
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page3();

            page.tbX0.Text = "0";
            page.tbXk.Text = "1";
            page.tbDx.Text = "0,5";
            page.tbB.Text = "1";

            page.BtnCalc_Click(null, null);

            // берем первую строку результата
            string firstLine = page.tbResult.Text.Split('\n')[0];

            // ожидаемое значение при x = 0
            double x = 0, b = 1;
            double arg = x + b - 0.0084;
            double y = x * Math.Sin(Math.Sqrt(arg));

            string expectedPart = y.ToString("F5");

            Assert.IsTrue(firstLine.Contains(expectedPart));
        }
    }
}