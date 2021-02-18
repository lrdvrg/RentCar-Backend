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
    public class VehiclesController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/Vehicles
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<VehicleDTO> GetVehicle()
        {
            return Mapper.Map<List<VehicleDTO>>(db.Vehicle.ToList());
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public VehicleDTO GetVehicle(int id)
        {
            Vehicle vehicle = db.Vehicle.Find(id);
            if (vehicle == null)
            {
                return null;
            }

            return Mapper.Map<VehicleDTO>(vehicle);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.VehicleId)
            {
                return BadRequest();
            }

            db.Entry(vehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicle.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.VehicleId }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = db.Vehicle.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicle.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicle.Count(e => e.VehicleId == id) > 0;
        }
    }
}