using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Model
{
    public class Incident
    {
        public ObjectId id;
        public Status status;
        public Priority priority;
        public DateTime deadline;
        public IncidentType incidentType;
        public ObjectId userReported;
        public string description;
        public DateTime reportedDate;
        public string subject;

       
        public Incident() { }
    }

   
}
