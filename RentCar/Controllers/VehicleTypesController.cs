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
    public class VehicleTypesController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/VehicleTypes
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<VehicleTypeDTO> GetVehicleType()
        {

            return Mapper.Map<List<VehicleTypeDTO>>(db.VehicleType.ToList());
        }

        // GET: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public VehicleTypeDTO GetVehicleType(int id)
        {
            VehicleType vehicleType = db.VehicleType.Find(id);
            if (vehicleType == null)
            {
                // return NotFound();
            }

            return Mapper.Map<VehicleTypeDTO>(vehicleType);
        }

        // PUT: api/VehicleTypes/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutVehicleType(int id, VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleType.VehicleTypeId)
            {
                return BadRequest();
            }

            db.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
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

        // POST: api/VehicleTypes
        [ResponseType(typeof(VehicleType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleType.Add(vehicleType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleType.VehicleTypeId }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteVehicleType(int id)
        {
            VehicleType vehicleType = db.VehicleType.Find(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            db.VehicleType.Remove(vehicleType);
            db.SaveChanges();

            return Ok(vehicleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleTypeExists(int id)
        {
            return db.VehicleType.Count(e => e.VehicleTypeId == id) > 0;
        }
    }
}