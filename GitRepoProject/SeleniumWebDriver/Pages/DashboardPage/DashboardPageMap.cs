using OpenQA.Selenium;

namespace SeleniumWebDriver.Pages.DashboardPage
{
    public partial class DashboardPage
    {
        public IWebElement Logout
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[3]/li[2]/a"));
            }
        }

        public IWebElement UsersLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[5]/a"));
            }
        }

        public IWebElement DepartmentsLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[2]/li[3]/a"));
            }
        }
    }
}
