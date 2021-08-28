using NUnit.Framework;
using MarsFramework.Config;
using MarsFramework.Pages;
using static MarsFramework.Global.GlobalDefinitions;
using System.Threading;
namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

           
                [Test]
                public void AddShareSkillTest()
                {
                    ShareSkill shareSkillobj = new ShareSkill();
                    shareSkillobj.EnterShareSkill();
                    Thread.Sleep(5000);

                }
                [Test]
                public void ViewRecord()
                {
                    ManageListings manageListingsobj = new ManageListings();
                    manageListingsobj.ViewManageListings();
                }
                [Test]
                public void DeleteRecord()
                {
                    ManageListings manageListingsobj = new ManageListings();
                    manageListingsobj.DeleteManageListing();
                }
                [Test]
                public void EditRecord()
                {
                    ManageListings manageListingsObj = new ManageListings();
                    manageListingsObj.EditeManagelisting();
                }


            }



        }
    }
