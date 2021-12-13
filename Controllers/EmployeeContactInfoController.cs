using EHI.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHI.Controllers
{
    public class EmployeeContactInfoController : ApiController
    {
       public Irepository<EmployeeContactInfoModel> objRepository;
        public EmployeeContactInfoController()
        {
            objRepository = new Repository<EmployeeContactInfoModel>();
        }
        // GET: api/EmployeeContactInfo
        public IEnumerable<EmployeeContactInfoModel> Get()
        {
            return objRepository.GetData();
        }

        // GET: api/EmployeeContactInfo/5
        public EmployeeContactInfoModel GetDataById(int id)
        {
            return objRepository.GetDataById(id);
        }

        // POST: api/EmployeeContactInfo
        public void Post([FromBody] EmployeeContactInfoModel Request)
        {
        }

        // PUT: api/EmployeeContactInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeContactInfo/5
        public void Delete(int id)
        {
        }
    }
}
