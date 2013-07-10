using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Service;
using Data.Model;

namespace Data.Test
{
    [TestClass]
    public class RecieptManagerTest
    {
        [TestMethod]
        public void CreateReciept()
        {
            var reciepts = new RecieptManager();

            var reciept = new Reciept();
            reciept.KingdomHallFund = 100;
            reciept.WorldWideWork = 100;
            reciept.Congregation = 200;

            reciepts.AddReciept(reciept);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Have An Unnamed Misc Field")]
        public void CreateReciept_Should_Throw_An_Error_If_A_Misc_Field_Is_Used_But_Not_Named()
        {
            var reciepts = new RecieptManager();

            var reciept = new Reciept();
            reciept.Miscellaneous1 = 100;

            reciepts.AddReciept(reciept);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Have A Negitive Value")]
        public void CreateReciept_Should_Throw_An_Error_If_Any_Field_Has_A_Negitive_Value()
        {
            var reciepts = new RecieptManager();

            var reciept = new Reciept();
            reciept.Miscellaneous1 = -100;

            reciepts.AddReciept(reciept);
        }

        [TestMethod]
        public void GetAllReciepts_Should_Never_Return_Null()
        {
            var reciepts = new RecieptManager();

            Assert.IsNotNull(reciepts.GetAllReciepts());
        }

        [TestMethod]
        public void GetAllReciepts_Should_Return_A_Previously_Saved_Reciept()
        {
            var reciepts = new RecieptManager();

            //Add new reciept
            var reciept = new Reciept();
            reciept.KingdomHallFund = 100;
            reciept.WorldWideWork = 100;
            reciept.Congregation = 200;
            reciepts.AddReciept(reciept);

            //list it back out
            var recieptsList = reciepts.GetAllReciepts();

            //make sure its in the list
            foreach (var rec in recieptsList)
            {
                if (rec.ID == reciept.ID &&
                    rec.Congregation == reciept.Congregation &&
                    rec.KingdomHallFund == reciept.KingdomHallFund &&
                    rec.WorldWideWork == reciept.WorldWideWork &&
                    rec.Miscellaneous1 == reciept.Miscellaneous1 &&
                    rec.Miscellaneous1Name == reciept.Miscellaneous1Name &&
                    rec.Miscellaneous2 == reciept.Miscellaneous2 &&
                    rec.Miscellaneous2Name == reciept.Miscellaneous2Name &&
                    rec.Date == reciept.Date)
                {
                    return;
                }
            }

            //If it wasnt in the list, then we didnt return. so we must not of 
            //been able to find the recipet in the database. this test must FAIL
            Assert.Fail();
        }

        [TestMethod]
        public void UpdateReciept_Shuould_Save_Chanes_In_The_Database()
        {
            var reciepts = new RecieptManager();

            //Add new reciept
            var originalReciept = new Reciept();
            originalReciept.KingdomHallFund = 100;
            originalReciept.WorldWideWork = 100;
            originalReciept.Congregation = 200;
            reciepts.AddReciept(originalReciept);

            //change something
            originalReciept.KingdomHallFund = 33;
            reciepts.UpdateReciept(originalReciept);
            
            //get it back out of the DB
            var newReciept  = reciepts.GetReciept(originalReciept.ID);

            //Compare it
            if (newReciept.ID != originalReciept.ID ||
                newReciept.Congregation != originalReciept.Congregation ||
                newReciept.KingdomHallFund != originalReciept.KingdomHallFund ||
                newReciept.WorldWideWork != originalReciept.WorldWideWork ||
                newReciept.Miscellaneous1 != originalReciept.Miscellaneous1 ||
                newReciept.Miscellaneous1Name != originalReciept.Miscellaneous1Name ||
                newReciept.Miscellaneous2 != originalReciept.Miscellaneous2 ||
                newReciept.Miscellaneous2Name != originalReciept.Miscellaneous2Name ||
                newReciept.Date != originalReciept.Date)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetReciept_Shuould_Return_Null_If_Reciept_Was_Not_Found()
        {
            var reciepts = new RecieptManager();

            Assert.IsNull(reciepts.GetReciept(Guid.NewGuid()));
        }

        [TestMethod]
        public void GetReciept_Should_Return_A_Previously_Saved_Reciept()
        {
            var reciepts = new RecieptManager();

            //Add new reciept
            var reciept = new Reciept();
            reciept.KingdomHallFund = 100;
            reciept.WorldWideWork = 100;
            reciept.Congregation = 200;
            reciepts.AddReciept(reciept);
            
            //get it back out of the DB
            var newReciept = reciepts.GetReciept(reciept.ID);

            Assert.IsNotNull(newReciept);

            //Compare it
            if (newReciept.ID != reciept.ID ||
                newReciept.Congregation != reciept.Congregation ||
                newReciept.KingdomHallFund != reciept.KingdomHallFund ||
                newReciept.WorldWideWork != reciept.WorldWideWork ||
                newReciept.Miscellaneous1 != reciept.Miscellaneous1 ||
                newReciept.Miscellaneous1Name != reciept.Miscellaneous1Name ||
                newReciept.Miscellaneous2 != reciept.Miscellaneous2 ||
                newReciept.Miscellaneous2Name != reciept.Miscellaneous2Name ||
                newReciept.Date != reciept.Date)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveReciept_Shuould_Delete_A_Reciept_From_The_Database()
        {
            var reciepts = new RecieptManager();

            //Add new reciept
            var reciept = new Reciept();
            reciept.KingdomHallFund = 100;
            reciept.WorldWideWork = 100;
            reciept.Congregation = 200;
            reciepts.AddReciept(reciept);

            //Make sure its there
            Assert.IsNotNull(reciepts.GetReciept(reciept.ID));

            //Now Delete it
            reciepts.RemoveReciept(reciept);

            //Make sure its NOT there
            Assert.IsNull(reciepts.GetReciept(reciept.ID));
        }

    }
}
