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
    public class DocentesController : ApiController
    {
        private AlumnosDBEntities db = new AlumnosDBEntities();

        // GET: api/Docentes
        public IQueryable<Docente> GetDocentes()
        {
            return db.Docentes;
        }

        // GET: api/Docentes/5
        [ResponseType(typeof(Docente))]
        public IHttpActionResult GetDocente(int id)
        {
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return NotFound();
            }

            return Ok(docente);
        }


        // POST: api/Docentes
        [ResponseType(typeof(Docente))]
        public IHttpActionResult PostDocente(Docente docente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Docentes.Add(docente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = docente.Id }, docente);
        }
    }
}