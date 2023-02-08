using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BankOtkrytieProject.PageObjects
{
    public class OtkrytieBankPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "a.main-page-header__sub-nav-logo")]
        private IWebElement openBankLogo;

        public OtkrytieBankPage(IWebDriver driver) : base(driver) { }

        internal bool IsBankLogoDisplayed()
        {
            return openBankLogo.Displayed;
        }
    }
}