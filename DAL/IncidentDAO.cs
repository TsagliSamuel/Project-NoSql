using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Model;

namespace DAL
{
    public class IncidentDAO : Base
    {
        public List<Incident> GetIncidents(List<BsonDocument> bsonDocument)
        {
            List<Incident> incidents = new List<Incident>();

            foreach (var i in bsonDocument)
            {
                Incident incident = new Incident()
                {
                    id = (ObjectId)i["_id"],
                    status = (Status)Enum.Parse(typeof(Status), i["Status"].ToString()),
                    priority = (Priority)Enum.Parse(typeof(Priority), i["Priority"].ToString()),
                    deadline = DateTime.Parse(i["Deadline"].ToString()),
                    incidentType = (IncidentType)Enum.Parse(typeof(IncidentType), i["IncidentType"].ToString()),
                    userReported = (ObjectId)i["UserReported"],
                    description = (string)i["Description"],
                    reportedDate = DateTime.Parse(i["ReportedDate"].ToString()),
                    subject = (string)i["Subject"]
                };
                incidents.Add(incident);
            }
            return incidents;
        }
        public List<Incident> GetAllIncidents(FilterDefinition<BsonDocument> filteredDocuments) 
        { 
            return GetIncidents(GetSpecificIncidents(incidentsCollection, filteredDocuments)); 
        }

        public List<Incident> GetAllIncidents()
        {
            return GetIncidents(GetAll(incidentsCollection));
        }

        public List<Incident> GetSpecificIncidents(string status, string column)
        {
            return GetIncidents(GetSpecificIncidents(incidentsCollection, status, column));
        }

       


    }
}
