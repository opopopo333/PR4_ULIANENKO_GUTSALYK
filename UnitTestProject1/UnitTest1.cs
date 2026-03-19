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
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page1();

            page.tbX.Text = "1";
            page.tbY.Text = "4";
            page.tbZ.Text = "1";
        
            Assert.IsFalse(string.IsNullOrEmpty(page.tbResult.Text));
        }
        
        /// <summary>
        /// Тест Page2 (ветка exp, |x*q| < 10)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page2();

            page.tbX.Text = "1";
            page.tbQ.Text = "2";
        
            page.rbExp.IsChecked = true; // выбираем exp(x)
        
            Assert.IsFalse(string.IsNullOrEmpty(page.tbResult.Text));
        }
        
        // <summary>
        // Тест Page3 (цикл и вычисление функции)
        // </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var page = new Практическая_работа_4_Ульяненко_Гуцалюк.Page3();

            page.tbX0.Text = "0";
            page.tbXk.Text = "1";
            page.tbDx.Text = "0.5";
            page.tbB.Text = "1";
        
            Assert.IsFalse(string.IsNullOrEmpty(page.tbResult.Text));
        }
    }
}
