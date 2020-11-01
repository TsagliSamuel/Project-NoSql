using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Logic
{
    public class IncidentLogic
    {
        IncidentDAO incidentDAO = new IncidentDAO();
        List<Incident> listOfIncidents;
        public List<Incident> getAllIncidents()
        {
            return incidentDAO.GetAllIncidents();
        }

        public List<Incident> getFilteredIncidents(FilterDefinition<BsonDocument> filterDocs)
        {
            return listOfIncidents = incidentDAO.GetAllIncidents(filterDocs);
            
        }

        public List<Incident> PastDeadlineTickets()
        {
            listOfIncidents = getAllIncidents();

            List<Incident> lists = new List<Incident>();
            try
            {  
                for (int i = 0; i < listOfIncidents.Count; i++)
                {
                    if (lists[i].deadline < DateTime.Now && lists[i].status == Status.Closed)
                    {
                        lists.Add(listOfIncidents[i]);
                    }
                } 
            }
            catch(Exception) { }
           
            return lists;

        }

        public List<Incident> GroupByStatus(Status status)
        {
            listOfIncidents = getAllIncidents();
            List<Incident> lists = new List<Incident>();

            try
            {
                for (int i = 0; i < listOfIncidents.Count; i++)
                {
                    if (listOfIncidents[i].status == status)
                    {
                        lists.Add(listOfIncidents[i]);
                    }
                }
            }
            catch (Exception) { }

           
            return lists;
        }

        public List<Incident> getClosedTickets()
        {
            return GroupByStatus(Status.Closed);
        }
        public List<Incident> getOpenedTickets()
        {
            return GroupByStatus(Status.Open);
        }
        public List<Incident> getTicketsPastDeadline()
        {
            return PastDeadlineTickets();
        }
        
       
    }
}
