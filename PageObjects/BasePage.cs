using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BankOtkrytieProject.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected const int WaitTimeout = 30;

        public BasePage(IWebDriver driver) 
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}