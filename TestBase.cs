using BankOtkrytieProject.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BankOtkrytieProject
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        protected GoogleSearchPage InitGoogleSearch()
        {
            driver.Navigate().GoToUrl(baseURL);

            return new GoogleSearchPage(driver);
        }
    }
}