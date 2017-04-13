using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using hopsital.Services;
using Hopsital.Models;

namespace Hopsital.Controllers
{
    //[Authorize]
    public class HospitalManagerController : ApiController
    {
	    private readonly PatientsRepository _patientsRepository;

	    public HospitalManagerController()
	    {
		    _patientsRepository = new PatientsRepository();
	    }

		[Route("api/patients")]
        public Patient[] Get()
		{
			return _patientsRepository.GetAllPetients();
		}

		[Route("api/patients/{id}")]
        public Patient Get(int id)
		{
			return _patientsRepository.GetAllPetients().FirstOrDefault(p => p.Id == id);
		}

		[Route("api/patients/insert")]
		[System.Web.Mvc.HttpPost]
		public HttpResponseMessage Post([FromBody]Patient patient)
		{
			_patientsRepository.SavePatient(patient);
			var response = Request.CreateResponse(HttpStatusCode.Created, patient);
			return response;
		}







        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
