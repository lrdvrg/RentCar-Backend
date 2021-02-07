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
using RentCar.Models;

namespace RentCar.Controllers
{
    public class BrandsController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/Brands
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<Brand> GetBrand()
        {
            return db.Brand;
        }

        // GET: api/Brands/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ResponseType(typeof(Brand))]
        public IHttpActionResult GetBrand(int id)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.BrandId)
            {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        [ResponseType(typeof(Brand))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brand.Add(brand);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brand.BrandId }, brand);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(Brand))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteBrand(int id)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            db.Brand.Remove(brand);
            db.SaveChanges();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id)
        {
            return db.Brand.Count(e => e.BrandId == id) > 0;
        }
    }
}