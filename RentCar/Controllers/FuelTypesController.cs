using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class FuelTypesController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/FuelTypes
        public IQueryable<FuelType> GetFuelType()
        {
            return db.FuelType;
        }

        // GET: api/FuelTypes/5
        [ResponseType(typeof(FuelType))]
        public IHttpActionResult GetFuelType(int id)
        {
            FuelType fuelType = db.FuelType.Find(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return Ok(fuelType);
        }

        // PUT: api/FuelTypes/5
        [ResponseType(typeof(void))]
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