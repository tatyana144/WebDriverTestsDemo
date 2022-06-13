
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Create new Chrome browser instance
var driver = new ChromeDriver();

//Navigate to Wikipedia
driver.Url = "https://www.wikipedia.org/";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

//Locate Search field by Id
var searchField = driver.FindElement(By.Id("searchInput"));

//Click on element
searchField.Click();

//FIll QA and press Enter keyboard button
searchField.SendKeys("QA" + Keys.Enter);

System.Console.WriteLine("TITLE AFTER SEARCH: " + driver.Title);


driver.Quit();
