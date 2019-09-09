﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.PersonTypes
{
    public class PersonTypeRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<PersonType> collection;

        public PersonTypeRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<PersonType>("personTypes");
        }

        public void Insert(PersonType documentType)
        {
            collection.InsertOne(documentType);
        }

        public List<PersonType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}