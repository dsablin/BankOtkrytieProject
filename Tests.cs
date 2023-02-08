using BankOtkrytieProject.PageObjects;
using NUnit.Framework;

namespace BankOtkrytieProject
{
    [TestFixture]
    public class Tests : TestBase
    {
        private readonly string _bankOtkrytieUrl = "https://www.open.ru/";

        [Test]
        public void LookForBankOtkrytieSite()
        {
            GoogleSearchPage google = InitGoogleSearch();

            google.SearchForValue("open.ru");
            var searchResults = google.CollectReferences();
            OtkrytieBankPage obPage = google.OpenUrlFromList(_bankOtkrytieUrl, searchResults);

            Assert.IsTrue(obPage.IsBankLogoDisplayed(), "Bank logo is not displayed unexpectedly.");
        }

    }
}