using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PeopleService
    {
        private readonly IMongoCollection<People> _people;
        private MongoClient client;
        public PeopleService(IPeopleStoreSettings setting)
        {
            client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _people = database.GetCollection<People>(setting.PeopleCollectionName);
        }
        public List<People> Get() => _people.Find(p => true).ToList();
        public People Get(string id) => _people.Find<People>(p => p.PersonId == id).FirstOrDefault();
        public People Add(People person)
        {
            using (var session = client.StartSession())
            {
                try
                {
                    session.StartTransaction();
                    _people.InsertOne(person);
                    //var filter = Builders<People>.Filter.Eq(p => p.FirstName, "Biss");
                    //var result = _people.DeleteOne(session, filter);
                    //if (result.DeletedCount == 0) throw new Exception("none");
                    session.CommitTransaction();
                }
                catch (Exception ex)
                {
                    session.AbortTransaction();
                }
                return person;
            }
        }
            public void Update(string Id, People person)
            {
                _people.ReplaceOne(p => p.PersonId == Id, person);
            }
            public void Delete(string id)
            {
                _people.DeleteOne(p => p.PersonId == id);
            }
        }
    }
