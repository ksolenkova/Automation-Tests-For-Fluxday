using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

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
            Thread.Sleep(1000);
            Assert.IsTrue(page.CreatedTeam.Displayed);
        }
    }
}
