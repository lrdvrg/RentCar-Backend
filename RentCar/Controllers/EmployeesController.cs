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
    public class EmployeesController : ApiController
    {
        private RentCarEntities db = new RentCarEntities();

        // GET: api/Employees
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<EmployeeDTO> GetEmployee()
        {
            return Mapper.Map<List<EmployeeDTO>>(db.Employee.ToList());
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public EmployeeDTO GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                //return NotFound();
            }

            return Mapper.Map<EmployeeDTO>(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.EmployeeId == id) > 0;
        }
    }
}