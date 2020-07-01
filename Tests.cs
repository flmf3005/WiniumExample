using NUnit.Framework;
using OpenQA.Selenium.Winium;
using System;

namespace WiniumExample
{
    public class Tests
    {
        public DesktopOptions options { get; set; }
        public WiniumDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            this.options = new DesktopOptions();
            options.ApplicationPath = @"C:\Windows\System32\calc.exe";
            this.Driver = new WiniumDriver(new Uri("http://localhost:9999"), options);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.FindElementByName("Fechar Calculadora").Click();
        }

        [Test]
        public void Calcular()
        {
            Driver.FindElementById("num2Button").Click();
            Driver.FindElementById("plusButton").Click();
            Driver.FindElementById("num3Button").Click();
            Driver.FindElementById("equalButton").Click();
            Assert.AreEqual("Exibição é 5", Driver.FindElementById("CalculatorResults").GetAttribute("Name"));
        }
    }
}