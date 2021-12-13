using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHI.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetData();

        /// <summary>
        /// Fetch Data by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetDataById(long Id);

        /// <summary>
        /// Insert data into DB
        /// </summary>
        /// <param name="data"></param>
        void InsertData(T data);

        /// <summary>
        /// Deete specific data from DB
        /// </summary>
        /// <param name="Id"></param>
        void DeleteData(int Id);

        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="data"></param>
        void UpdateData(T data);

        /// <summary>
        /// Save data 
        /// </summary>
        void Save();
    }
}
