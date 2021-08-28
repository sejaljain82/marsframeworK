using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    public class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void ViewManageListings()
        {
            try
            {
                GlobalDefinitions.wait(5);
                manageListingsLink.Click();
                view.Click();
                wait(5);
            }
            catch
            { Assert.Fail("Failed to View Record"); }
            IWebElement ViewAverageRatings = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[2]/div/h3"));
            if (ViewAverageRatings.Text == "Average Ratings")
            {
                Assert.Pass("Record can be Viewed");

            }
            else { Assert.Fail("Failed to View Record"); }
            Thread.Sleep(5000);

        }
        internal void DeleteManageListing()
        {
            try
            {
                //Populate the Excel Sheet
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
                wait(5);
                manageListingsLink.Click();
                wait(5);
                Thread.Sleep(5000);
                delete.Click();
                wait(5);
                if (ExcelLib.ReadData(2, "Deleteaction") == "Yes")
                {
                    IWebElement yesbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
                    yesbutton.Click();
                }
                else
                {
                    IWebElement nobutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
                    nobutton.Click();
                }
            }
            catch
            {
                Assert.Fail("Failed to Delete the Record");
            }
            Thread.Sleep(2000);
            IWebElement MLtitel = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h2"));
            if (MLtitel.Text == "Manage Listings")
            {
                Assert.Pass("Record Deleted");

            }
            else { Assert.Fail("Failed to Delete Record"); }
            Thread.Sleep(5000);

        }

        internal void EditeManagelisting()
        {
            wait(5);
            manageListingsLink.Click();
            wait(5);
            edit.Click();
            Thread.Sleep(5000);
            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.EditShareSkill();
            Thread.Sleep(5000);

        }

    }
}
