using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 c = new Class1();
            double h = c.CalorieIntake(88,173,22,5,1.2,0.99);
            Assert.AreEqual(2583.9, h);
        }
    }
}
