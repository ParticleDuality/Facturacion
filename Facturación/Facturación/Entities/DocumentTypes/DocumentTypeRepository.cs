﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Facturación.Entities.DocumentTypes
{
    public class DocumentTypeRepository
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<DocumentType> collection;

        public DocumentTypeRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<DocumentType>("documentTypes");
        }

        public void Insert(DocumentType documentType)
        {
            collection.InsertOne(documentType);
        }
        public void Update(ObjectId id, BsonDocument doc)
        {
            var filter = Builders<DocumentType>.Filter.Eq("_id", id);
            var item = Builders<DocumentType>.Update.Set("Code", doc.GetValue("code")).Set("Name", doc.GetValue("name"));
            collection.FindOneAndUpdate(filter, item);
        }
        public void Delete(ObjectId id)
        {
            collection.FindOneAndDelete(Builders<DocumentType>.Filter.Eq("_id", id));
        }
        public List<DocumentType> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
        public DocumentType Get(ObjectId id)
        {
            return collection.Find<DocumentType>(dt => dt.Id == id).FirstOrDefault();
        }
    }
}