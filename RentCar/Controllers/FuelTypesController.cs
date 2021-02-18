using System;
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
    public class FuelTypesController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/FuelTypes
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<FuelTypeDTO> GetFuelType()
        {
            return Mapper.Map<List<FuelTypeDTO>>(db.FuelType.ToList());
        }

        // GET: api/FuelTypes/5
        [ResponseType(typeof(FuelType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public FuelTypeDTO GetFuelType(int id)
        {
            FuelType fuelType = db.FuelType.Find(id);
            if (fuelType == null)
            {
                //return NotFound();
            }

            return Mapper.Map<FuelTypeDTO>(fuelType);
        }

        // PUT: api/FuelTypes/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutFuelType(int id, FuelType fuelType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fuelType.FuelTypeId)
            {
                return BadRequest();
            }

            db.Entry(fuelType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelTypeExists(id))
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

        // POST: api/FuelTypes
        [ResponseType(typeof(FuelType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostFuelType(FuelType fuelType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FuelType.Add(fuelType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fuelType.FuelTypeId }, fuelType);
        }

        // DELETE: api/FuelTypes/5
        [ResponseType(typeof(FuelType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteFuelType(int id)
        {
            FuelType fuelType = db.FuelType.Find(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            db.FuelType.Remove(fuelType);
            db.SaveChanges();

            return Ok(fuelType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuelTypeExists(int id)
        {
            return db.FuelType.Count(e => e.FuelTypeId == id) > 0;
        }
    }
}