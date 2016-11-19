using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Controllers
{
    [EnableCors("*","*","GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> patients;

        public PatientsController()
        {
            patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            // Select all
            var filte = Builders<Patient>.Filter.Ne("Name","");
            return patients.Find(filte).ToList();
        }

        public IHttpActionResult Get(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", ObjectId.Parse(id));
            var patient = patients.Find(filter).ToList();
            if(patient == null || patient.Count == 0)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [Route("api/patients/{id}/medication")]
        public IHttpActionResult GetMedications(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", ObjectId.Parse(id));
            var patient = patients.Find(filter).ToList();
            if (patient == null || patient.Count == 0)
            {
                return NotFound();
            }

            return Ok(patient.First().Medications);
        }
    }
}
