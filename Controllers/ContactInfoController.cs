
using EHI.Models;
using EHI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EHI.Controllers
{
    //to enable CORS should add be attribute 
    //[EnableCors(origins: "http://localhost.com/test", headers: "*", methods: "*")]
    public class ContactInfoController : ApiController
    {
        public IRepository<EmpContactInfo> objRepository;
        public ContactInfoController()
        {
            objRepository = new Repository<EmpContactInfo>();
        }


        [Route("~/EHI/GetContactInformation")]
        public IEnumerable<EmpContactInfo> Get()
        {
            return objRepository.GetData();
        }

        [Route("~/EHI/GetContactInformationById")]
        public EmpContactInfo GetDataById(long id)
        {
            return objRepository.GetDataById(id);
        }

        [Route("~/EHI/InsertContactInformation")]
        public IHttpActionResult Post([FromBody] EmpContactInfo Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            objRepository.InsertData(Request);
            objRepository.Save();
            return Ok(this.Get().OrderByDescending(x => x.Id));
        }

        [Route("~/EHI/UpdateContactInformation")]
        public IHttpActionResult Put(long id,   EmpContactInfo Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != Request.Id)
            {
                return BadRequest();
            }

            objRepository.UpdateData(Request);
            objRepository.Save();

            return Ok(this.GetDataById(id));
        }

        [Route("~/EHI/DeleteContactInformation")]
        public IHttpActionResult Delete(int id)
        {
            objRepository.DeleteData(id);
            objRepository.Save();

            return Ok(this.Get());
        }
    }
}