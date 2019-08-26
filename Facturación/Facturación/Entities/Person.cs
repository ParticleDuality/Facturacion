﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturación.Entities
{
    public sealed class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("PersonType")]
        public string PersonType { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("Surname")]
        public string Surname { get; set; }
        [BsonElement("IdentificationType")]
        public string IdentificationType { get; set; }
        [BsonElement("IdentificationNumber")]
        public string IdentificationNumber { get; set; }

    }
}