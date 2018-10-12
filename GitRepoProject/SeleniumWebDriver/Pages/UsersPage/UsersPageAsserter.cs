using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebDriver.Pages.UsersPage
{
    public static class UsersPageAsserter
    {
        public static void AssertNewlyCreatedUserIsDisplayed(this UsersPage page)
        {
            Assert.IsTrue(page.NewCreatedUser.Displayed);
        }

        public static void AssertUserIsDeleted(this UsersPage page)
        {
            Assert.IsNotNull(page.UserToDelete);
        }
    }
}
