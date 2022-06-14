using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {

        private ChromeDriver driver;
        IWebElement firstField;
        IWebElement secondField;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";

            firstField = driver.FindElement(By.Id("number1"));
            secondField = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();

        }

        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("-1", "-2", "-", "Result: 1")]
        [TestCase("-3", "5", "+", "Result: 2")]
        [TestCase("520", "6", "+", "Result: 526")]
        [TestCase("10.2", "6", "-", "Result: 4.2")]
        [TestCase("10", "2", "/", "Result: 5")]
        [TestCase("20", "3", "/", "Result: 6.66666666667")]
        [TestCase("20", "3", "*", "Result: 60")]
        public void Test_Calculator(string numOne, string numTwo, string operationSumbol, string result)
        {

            //Act
            firstField.SendKeys(numOne);
            operation.SendKeys(operationSumbol);
            secondField.SendKeys(numTwo);

            calculate.Click();

            //Assert
            Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click();

        }
    }
}