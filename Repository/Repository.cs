using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EHI.Models;
namespace EHI.Repository
{
    //Implement Generic repository 
    public class Repository<T> : IRepository<T> where T : class
    {
        private EHI_Contact_InfoEntities1 ehiDbContext;
        private IDbSet<T> dbEntities;

        //Constructor to create db object & set db entity of particular class
        public Repository()
        {
            ehiDbContext = new EHI_Contact_InfoEntities1();

            //Use to set db entity of particular class which we pass 
            dbEntities = ehiDbContext.Set<T>();
        }


        /// <summary>
        /// Deete specific data from DB
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteData(int Id)
        {
            T data = dbEntities.Find(Id);
            dbEntities.Remove(data);
        }

        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetData()
        {
            return dbEntities.ToList();
        }

        /// <summary>
        /// Fetch Data by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetDataById(long Id)
        {
            return dbEntities.Find(Id);
        }

        /// <summary>
        /// Insert data into DB
        /// </summary>
        /// <param name="data"></param>
        public void InsertData(T data)
        {
            dbEntities.Add(data);
        }

        /// <summary>
        /// Save data 
        /// </summary>
        public void Save()
        {
            ehiDbContext.SaveChanges();
        }

        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="data"></param>
        public void UpdateData(T data)
        {
            ehiDbContext.Entry(data).State = EntityState.Modified;
        }
    }
}