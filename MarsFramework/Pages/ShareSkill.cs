using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Config;
using MarsFramework.Pages;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
//using AutoItX3Lib;

namespace MarsFramework.Pages
{
    public class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]

        private IWebElement ShareSkillButton { get; set; }
        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement ServiceTypeOptions { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement ServiceTypeOptions1 { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement LocationTypeOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Online { get; set; }


        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }


        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credit { get; set; }
        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement ActiveOption1 { get; set; }
        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }
        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
        int Count;
        internal void EnterShareSkill()
        {
            try
            {
                wait(5);
                // Ckick on Share skills Button
                ShareSkillButton.Click();
                wait(5);

                //Read the Titel from excel file and enter on the titel box
                ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ShareSkills");
                Title.SendKeys(ExcelLib.ReadData(2, "Title"));

                //Read the Description from excel file and enter on the Description box
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));

                //Create a SelectElement object to access drop down box 
                var SelecCategory = new SelectElement(CategoryDropDown);

                //Set the Category that is ther in the Excel sheet
                SelecCategory.SelectByText(ExcelLib.ReadData(2, "Category"));

                //Create a SelectElement object to access drop down box 
                var SelecSubCategory = new SelectElement(SubCategoryDropDown);

                //Set the Language level that is ther in the Excel sheet
                SelecSubCategory.SelectByText(ExcelLib.ReadData(2, "SubCategory"));

                //Read the Tag from excel file and enter on the tag box
                Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);

                //Select the Service type option
                if (ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
                {

                    ServiceTypeOptions.Click();
                }
                else
                {
                    ServiceTypeOptions1.Click();
                }

                //Select the Location option
                if (ExcelLib.ReadData(2, "LocationType") == "On-site")
                {
                    LocationTypeOption.Click();
                }
                else
                {
                    Online.Click();
                }


                //Select the Start Date
                StartDateDropDown.SendKeys(ExcelLib.ReadData(2, "Startdate"));
                //Select the End date
                EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "Enddate"));

                //Creating a list for Day ,Start Time and End Time 
                IList<IWebElement> Starttime = driver.FindElements(By.Name("StartTime"));
                IList<IWebElement> Endtime = driver.FindElements(By.Name("EndTime"));
                IList<IWebElement> DaysCheckbox = driver.FindElements(By.XPath("(//input[@name='Available'])"));
                Count = DaysCheckbox.Count;

                DaysCheckbox.ElementAt(1).Click();

                Starttime.ElementAt(1).SendKeys(ExcelLib.ReadData(2, "Starttime"));

                Endtime.ElementAt(1).SendKeys(ExcelLib.ReadData(2, "Endtime"));
                //
                if (ExcelLib.ReadData(2, "SkillTrade") == "Skill-exchange")
                {
                    SkillTradeOption.Click();
                    SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);

                }
                else
                {
                    Credit.Click();
                    CreditAmount.SendKeys(ExcelLib.ReadData(2, "Credit"));
                }

              /*  WorkSample.Click();
               AutoItX3 autoWorkSampleObj = new AutoItX3();
                autoWorkSampleObj.WinActivate("Open");
                Thread.Sleep(1000);
                autoWorkSampleObj.Send(ExcelLib.ReadData(2, "WorkSamples"));
                Thread.Sleep(1000);
                autoWorkSampleObj.Send("{ENTER}");
                Thread.Sleep(3000);*/

                if (ExcelLib.ReadData(2, "Active") == "Active")

                {
                    ActiveOption.Click();
                }
                else
                {
                    ActiveOption1.Click();
                }


                Save.Click();
            }
            catch
            {
                Assert.Fail("Failed to Add Record");
            }
            wait(5);

            IWebElement MLtitel = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h2"));
            if (MLtitel.Text == "Manage Listings")
            {
                Assert.Pass("Record Added");

            }
            else { Assert.Fail("Failed to Add Record"); }
            Global.GlobalDefinitions.wait(5);
            Thread.Sleep(2000);


        }

        internal void EditShareSkill()
        {
            try
            {
                wait(5);

                ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ShareSkills");
                //Read the Titel from excel file and Edit the titel box
                Title.Clear();
                Title.SendKeys(ExcelLib.ReadData(5, "Title"));

                //Read the Description from excel file and enter on the Description box
                Description.Clear();
                Description.SendKeys(ExcelLib.ReadData(5, "Description"));

                //Create a SelectElement object to access drop down box 
                var SelecCategory = new SelectElement(CategoryDropDown);

                //Set the Category that is ther in the Excel sheet
                SelecCategory.SelectByText(ExcelLib.ReadData(5, "Category"));

                //Create a SelectElement object to access drop down box 
                var SelecSubCategory = new SelectElement(SubCategoryDropDown);

                //Set the Language level that is ther in the Excel sheet
                SelecSubCategory.SelectByText(ExcelLib.ReadData(5, "SubCategory"));

                //Read the Tag from excel file and enter on the tag box
                Tags.Clear();
                Tags.SendKeys(ExcelLib.ReadData(5, "Tags"));
                Tags.SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                //Select the Service type option
                if (ExcelLib.ReadData(5, "ServiceType") == "Hourly basis service")
                {

                    ServiceTypeOptions.Click();
                }
                else
                {
                    ServiceTypeOptions1.Click();
                }

                Thread.Sleep(2000);
                //Select the Location option
                if (ExcelLib.ReadData(5, "LocationType") == "On-site")
                {
                    LocationTypeOption.Click();
                }
                else
                {
                    Online.Click();
                }

                //Creating a list for Day ,Start Time and End Time 
                IList<IWebElement> Starttime = driver.FindElements(By.Name("StartTime"));
                IList<IWebElement> Endtime = driver.FindElements(By.Name("EndTime"));
                IList<IWebElement> DaysCheckbox = driver.FindElements(By.XPath("(//input[@name='Available'])"));
                Count = DaysCheckbox.Count;
                Thread.Sleep(2000);
                DaysCheckbox.ElementAt(5).Click();
                Thread.Sleep(2000);
                Starttime.ElementAt(5).SendKeys(ExcelLib.ReadData(5, "Starttime"));
                Thread.Sleep(1500);
                Endtime.ElementAt(5).SendKeys(ExcelLib.ReadData(5, "Endtime"));
                //
                if (ExcelLib.ReadData(5, "SkillTrade") == "Skill-exchange")
                {
                    SkillTradeOption.Click();
                    SkillExchange.SendKeys(ExcelLib.ReadData(5, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);

                }
                else
                {
                    Credit.Click();
                    CreditAmount.SendKeys(ExcelLib.ReadData(5, "Credit"));
                }

               /* WorkSample.Click();
                AutoItX3 autoWorkSampleObj = new AutoItX3();
                autoWorkSampleObj.WinActivate("Open");
                Thread.Sleep(1500);
                autoWorkSampleObj.Send(ExcelLib.ReadData(5, "WorkSamples"));
                Thread.Sleep(1500);
                autoWorkSampleObj.Send("{ENTER}");
                Thread.Sleep(3000);*/

                if (ExcelLib.ReadData(5, "Active") == "Active")

                {
                    ActiveOption.Click();
                }
                else
                {
                    ActiveOption1.Click();
                }


                Save.Click();
            }
            catch
            {
                Assert.Fail("Failed to Edit the Record");
            }
            Thread.Sleep(2000);
            IWebElement MLtitel = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h2"));
            if (MLtitel.Text == "Manage Listings")
            {
                Assert.Pass("Record Edited");

            }
            else { Assert.Fail("Failed to Edit Record"); }

        }
    }
}
