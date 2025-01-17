﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using RentCar.DTOs;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class ModelsController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/Models
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<ModelDTO> GetModel()
        {

             var students = AutoMapper.Mapper.Map<List<DTOs.ModelDTO>>(db.Model.ToList());


            return Mapper.Map<List<ModelDTO>>(db.Model.ToList());
        }

        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ModelDTO GetModel(int id)
        {
            Model model = db.Model.Find(id);
            if (model == null)
            {
                // return NotFound();
            }

            return Mapper.Map<ModelDTO>(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ModelId)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Models
        [ResponseType(typeof(Model))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Model.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.ModelId }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteModel(int id)
        {
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Model.Remove(model);
            db.SaveChanges();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Model.Count(e => e.ModelId == id) > 0;
        }
    }
}