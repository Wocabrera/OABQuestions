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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TestColorsController : ApiController
    {
        private OABQuestionsContext db = new OABQuestionsContext();

        // GET: api/TestColors
        public IQueryable<TestColor> GetTestColors()
        {
            return db.TestColors;
        }

        // GET: api/TestColors/5
        [ResponseType(typeof(TestColor))]
        public IHttpActionResult GetTestColor(int id)
        {
            TestColor testColor = db.TestColors.Find(id);
            if (testColor == null)
            {
                return NotFound();
            }

            return Ok(testColor);
        }

        // PUT: api/TestColors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestColor(int id, TestColor testColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testColor.TestColorId)
            {
                return BadRequest();
            }

            db.Entry(testColor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestColorExists(id))
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

        // POST: api/TestColors
        [ResponseType(typeof(TestColor))]
        public IHttpActionResult PostTestColor(TestColor testColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestColors.Add(testColor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testColor.TestColorId }, testColor);
        }

        // DELETE: api/TestColors/5
        [ResponseType(typeof(TestColor))]
        public IHttpActionResult DeleteTestColor(int id)
        {
            TestColor testColor = db.TestColors.Find(id);
            if (testColor == null)
            {
                return NotFound();
            }

            db.TestColors.Remove(testColor);
            db.SaveChanges();

            return Ok(testColor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestColorExists(int id)
        {
            return db.TestColors.Count(e => e.TestColorId == id) > 0;
        }
    }
}