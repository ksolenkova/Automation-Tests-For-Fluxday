using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebDriver.Pages.DepartmentsPage
{
    public static class DepartmentsPageAsserter
    {
        public static void AssertNewlyCreatedDepartmentIsDisplayed(this DepartmentsPage page)
        {
            Assert.IsTrue(page.NewlyCreatedDepartment.Displayed);
        }

        public static void AssertTheNewTeamIsDisplayed(this DepartmentsPage page)
        {
            Assert.IsTrue(page.CreatedTeam.Displayed);
        }
    }
}
