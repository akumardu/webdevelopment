using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Controllers
{
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

        public HttpResponseMessage Get(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", ObjectId.Parse(id));
            var patient = patients.Find(filter).ToList();
            if(patient == null || patient.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }

            return Request.CreateResponse(patient.First());
        }
    }
}
