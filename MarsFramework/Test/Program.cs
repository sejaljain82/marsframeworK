using NUnit.Framework;
using MarsFramework.Config;
using MarsFramework.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using System.Threading;
using RelevantCodes.ExtentReports;


namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

           
                [Test,Order(1)]
                
                public void AddShareSkillTest()
                {
                    ShareSkill shareSkillobj = new ShareSkill();
                    shareSkillobj.EnterShareSkill();
                    Thread.Sleep(5000);
               
                }
                [Test,Order(3)]
                public void ViewRecord()
                {
                    ManageListings manageListingsobj = new ManageListings();
                    manageListingsobj.ViewManageListings();
                }
                [Test,Order(4)]
                public void DeleteRecord()
                {
                    ManageListings manageListingsobj = new ManageListings();
                    manageListingsobj.DeleteManageListing();
                }
                [Test ,Order(2)]

                public void EditRecord()
                {
                    ManageListings manageListingsObj = new ManageListings();
                    manageListingsObj.EditeManagelisting();
                }


            }



        }
    }
