using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class RecieptManager
    {

        private Database database = null;

        /// <summary>
        /// ctor
        /// </summary>
        public RecieptManager()
        {
            database = new Database();
        }

        /// <summary>
        /// Add a new recipet to the store
        /// </summary>
        /// <param name="reciept"></param>
        public void AddReciept(Reciept reciept)
        {
            //Do not allow unnamed amounts
            if (reciept.Miscellaneous1 != 0 && reciept.Miscellaneous1Name == "")
            {
                throw new Exception("Cannot Have An Unnamed Misc Field");
            }
            if (reciept.Miscellaneous2 != 0 && reciept.Miscellaneous2Name == "")
            {
                throw new Exception("Cannot Have An Unnamed Misc Field");
            }

            //do not allow negitive numbers
            if (reciept.WorldWideWork < 0 ||
                reciept.Congregation < 0 ||
                reciept.KingdomHallFund < 0 ||
                reciept.Miscellaneous1 < 0 ||
                reciept.Miscellaneous2 < 0)
            {
                throw new Exception("Cannot Have A Negitive Value");
            }

            //All good. Allow it into the database
            database.Reciepts.Add(reciept);
            database.SaveChanges();
        }

        /// <summary>
        /// Return all reciepts
        /// </summary>
        /// <returns></returns>
        public List<Reciept> GetAllReciepts()
        {
            return database.Reciepts.OrderByDescending(col => col.Date).ToList();
        }

        /// <summary>
        /// Edit a reciept
        /// </summary>
        /// <returns></returns>
        public void UpdateReciept(Reciept reciept)
        {
            database.SaveChanges();
        }

        /// <summary>
        /// Edit a reciept
        /// </summary>
        /// <returns></returns>
        public void RemoveReciept(Reciept reciept)
        {
            database.Reciepts.Remove(reciept);
            database.SaveChanges();
        }

        /// <summary>
        /// Return a single Reciept by its ID
        /// </summary>
        /// <param name="ID"></param>
        public Reciept GetReciept(Guid ID)
        {
            return database.Reciepts.Where(col => col.ID == ID).FirstOrDefault();
        }
    }
}
