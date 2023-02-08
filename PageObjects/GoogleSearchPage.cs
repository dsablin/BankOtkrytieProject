using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace BankOtkrytieProject.PageObjects
{
    public class GoogleSearchPage : BasePage
    {
        private IWebDriver driver;

        #region Map of Elements

        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        private IWebElement searchFileld;

        [FindsBy(How = How.XPath, Using = "//input[@name='btnK']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='presentation']/div/ul[@role='listbox']")]
        private IWebElement hintsList;

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement searchResultsPane;

        [FindsBy(How = How.XPath, Using = "//*[@id='search']//div/a[@data-ved]")]
        private IList<IWebElement> searchResultsList;

        #endregion

        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
           this.driver = driver;
        }

        internal void SearchForValue(string text)
        {
            searchFileld.Click();
            searchFileld.SendKeys(text);
            WaitElement(hintsList);
            //searchFileld.SendKeys(Keys.Enter); //alternate way
            searchButton.Click();
        }

        internal IList<IWebElement> CollectReferences()
        {
            WaitElement(searchResultsPane);
            return GetReferencesList();
        }

        internal OtkrytieBankPage OpenUrlFromList(string url, IList<IWebElement> resultsList)
        {
            foreach (var item in resultsList)
            {
                var href = item.GetAttribute("href");
                if (href.Equals(url))
                {
                    item.Click();
                    //driver.Navigate().GoToUrl(href );
                    break;
                }
            }
            return new OtkrytieBankPage(driver);
        }

        private IList<IWebElement> GetReferencesList()
        {
            var result = new List<IWebElement>();
            foreach (IWebElement elem in searchResultsList)
            {
                result.Add(elem);
            }
            return result;
        }

        private void WaitElement(IWebElement element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTimeout));

            wait.Until(driver =>
            {
                return element.Displayed;
            });
        }
    }
}
