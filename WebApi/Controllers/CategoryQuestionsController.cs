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
    public class CategoryQuestionsController : ApiController
    {
        private OABQuestionsContext db = new OABQuestionsContext();

        // GET: api/CategoryQuestions
        public IQueryable<CategoryQuestion> GetCategoryQuestions()
        {
            return db.CategoryQuestions;
        }

        // GET: api/CategoryQuestions/5
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult GetCategoryQuestion(int id)
        {
            CategoryQuestion categoryQuestion = db.CategoryQuestions.Find(id);
            if (categoryQuestion == null)
            {
                return NotFound();
            }

            return Ok(categoryQuestion);
        }

        // PUT: api/CategoryQuestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoryQuestion(int id, CategoryQuestion categoryQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryQuestion.CategoryQuestionId)
            {
                return BadRequest();
            }

            db.Entry(categoryQuestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryQuestionExists(id))
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

        // POST: api/CategoryQuestions
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult PostCategoryQuestion(CategoryQuestion categoryQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryQuestions.Add(categoryQuestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoryQuestion.CategoryQuestionId }, categoryQuestion);
        }

        // DELETE: api/CategoryQuestions/5
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult DeleteCategoryQuestion(int id)
        {
            CategoryQuestion categoryQuestion = db.CategoryQuestions.Find(id);
            if (categoryQuestion == null)
            {
                return NotFound();
            }

            db.CategoryQuestions.Remove(categoryQuestion);
            db.SaveChanges();

            return Ok(categoryQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryQuestionExists(int id)
        {
            return db.CategoryQuestions.Count(e => e.CategoryQuestionId == id) > 0;
        }
    }
}