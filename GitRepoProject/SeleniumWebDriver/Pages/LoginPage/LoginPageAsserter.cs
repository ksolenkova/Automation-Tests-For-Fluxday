using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebDriver.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        public static void AssertFluxdayLogoIsDisplayed(this LoginPage page)
        {
            Assert.IsTrue(page.LoginButton.Displayed);
        }
    }
}
