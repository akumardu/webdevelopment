using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using webapi.Models;

namespace webapi
{
    public class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();
            if(!patients.AsQueryable().Any(p => p.Name == "Amar"))
            {
                var data = new List<Patient>()
                {
                    new Patient {Name = "Amar",
                                Ailments = new List<Ailment>() {new Ailment { Name="Nothing"}, new Ailment { Name="really nothing"} },
                                Medications = new List<Medication>() {new Medication { Name="Awesomeness", Doses="Daily"} }
                    }
                };

                patients.InsertMany(data);
            }
        }
    }
}