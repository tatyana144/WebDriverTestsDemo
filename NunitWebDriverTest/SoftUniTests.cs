using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTest
{
    public class SoftUniTests
    {
        private WebDriver driver;


        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();

        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {

            //Act
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
            
        }


        [Test]
        public void Test_AssertAboutUsTitle()
        {

            //Act
            var aboutUs = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            aboutUs.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_AsserSearchTitle()
        {
            driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search")).Click();



            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");
            searchBox.SendKeys(Keys.Enter);

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedValue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedValue));


        }
    }
}