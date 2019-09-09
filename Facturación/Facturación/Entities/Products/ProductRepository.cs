﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities.Products
{
    public class ProductRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Product> collection;

        public ProductRepository()
        {
            client = new MongoClient();
            database = client.GetDatabase("facturacion");
            collection = database.GetCollection<Product>("products");
        }

        public void Insert(Product product)
        {
            collection.InsertOne(product);
        }

        public List<Product> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}