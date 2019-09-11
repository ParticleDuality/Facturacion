﻿using Facturación.Entities.DocumentTypes;
using Facturación.Entities.Persons;
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Facturación.Areas.Setup.Controllers
{
    public class PersonsController : Controller
    {
        readonly PersonRepository repository = new PersonRepository();
        public ActionResult Index()
        {
            try
            {
                var list = repository.GetAll();
                return View(list);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                repository.Insert(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var person = repository.Get(objectId);
                return View(person);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, string personType, string firstName, string surName, string identificationType, string identificationNumber, int phone)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var doc = new BsonDocument
                {
                    { "personType", personType },
                    { "firstName", firstName },
                    { "surName", surName },
                    { "identificationType", identificationType },
                    { "identificationNumber", identificationNumber },
                    { "phone", phone }
                };
                repository.Update(objectId, doc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                repository.Delete(objectId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
