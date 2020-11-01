using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAL
{
    public abstract class Base
    {
        protected MongoClient dbClient;
        protected IMongoDatabase database;        
        protected string incidentsCollection = "Incidents"; 


        public Base()
        {
            dbClient = new MongoClient("mongodb+srv://Group1DB:group1database@cluster0.ymqob.mongodb.net/Group1DB?retryWrites=true&w=majority");
            database = dbClient.GetDatabase("Group1DB");
            
        }
        protected List<BsonDocument> GetAll(string collections)
        {
            var collection = database.GetCollection<BsonDocument>(collections);
            var emptyFilter = Builders<BsonDocument>.Filter.Empty; //empty filter to get all documents
            var docs = collection.Find(emptyFilter).ToList();
            return docs;
        }
        protected List<BsonDocument> GetSpecificIncidents(string collections,string attribute,string value) //getting incidents by string 
        {

            var collection = database.GetCollection<BsonDocument>(collections);
            var filterEq = Builders<BsonDocument>.Filter.Eq(attribute, value);
            var docs = collection.Find(filterEq).ToList();
            return docs;
        }
        protected List<BsonDocument> GetSpecificIncidents(string collections, FilterDefinition<BsonDocument> filteredDocument) //filtering incidents by filterDefinition in docs
        {
            var collection = database.GetCollection<BsonDocument>(collections);
            var docs  = collection.Find(filteredDocument).ToList();
            return docs;
        }

        
    }
}
