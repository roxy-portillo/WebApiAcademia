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
using WebApiAcademia;

namespace WebApiAcademia.Controllers
{
    public class MateriasController : ApiController
    {
        private AlumnosDBEntities db = new AlumnosDBEntities();

        // GET: api/Materias
        public IQueryable<Materias> GetMaterias()
        {
            return db.Materias;
        }

        // GET: api/Materias/5
        [ResponseType(typeof(Materias))]
        public IHttpActionResult GetMaterias(int id)
        {
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return NotFound();
            }

            return Ok(materias);
        }

       
        // POST: api/Materias
        [ResponseType(typeof(Materias))]
        public IHttpActionResult PostMaterias(Materias materias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materias.Add(materias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materias.Id }, materias);
        }
    }
}