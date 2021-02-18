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
    public class RentAndRefundsController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/RentAndRefunds
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<RentAndRefundDTO> GetRentAndRefund()
        {
            return Mapper.Map<List<RentAndRefundDTO>>(db.RentAndRefund.ToList());
        }

        // GET: api/RentAndRefunds/5
        [ResponseType(typeof(RentAndRefund))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public RentAndRefundDTO GetRentAndRefund(int id)
        {
            RentAndRefund rentAndRefund = db.RentAndRefund.Find(id);
            if (rentAndRefund == null)
            {
               // return NotFound();
            }

            return Mapper.Map<RentAndRefundDTO>(rentAndRefund);
        }

        // PUT: api/RentAndRefunds/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutRentAndRefund(int id, RentAndRefund rentAndRefund)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentAndRefund.RentAndRefundId)
            {
                return BadRequest();
            }

            db.Entry(rentAndRefund).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentAndRefundExists(id))
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

        // POST: api/RentAndRefunds
        [ResponseType(typeof(RentAndRefund))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostRentAndRefund(RentAndRefund rentAndRefund)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentAndRefund.Add(rentAndRefund);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentAndRefund.RentAndRefundId }, rentAndRefund);
        }

        // DELETE: api/RentAndRefunds/5
        [ResponseType(typeof(RentAndRefund))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteRentAndRefund(int id)
        {
            RentAndRefund rentAndRefund = db.RentAndRefund.Find(id);
            if (rentAndRefund == null)
            {
                return NotFound();
            }

            db.RentAndRefund.Remove(rentAndRefund);
            db.SaveChanges();

            return Ok(rentAndRefund);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentAndRefundExists(int id)
        {
            return db.RentAndRefund.Count(e => e.RentAndRefundId == id) > 0;
        }
    }
}