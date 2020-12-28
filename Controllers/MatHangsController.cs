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
using WebQuangTriKinhDoanh.DBContext;
using WebQuangTriKinhDoanh.Models;

namespace WebQuangTriKinhDoanh.Controllers
{
    [RoutePrefix("MatHangs")]
    public class MatHangsController : ApiController
    {
        private DBcontextLayer db = new DBcontextLayer();

        [Route("")]
        public ICollection<MatHang> GetmatHangs()
        {
            return db.matHangs.ToList();
        }

        // GET: api/MatHangs/5
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult GetMatHang(Guid id)
        {
            MatHang matHang = db.matHangs.Find(id);
            if (matHang == null)
            {
                return NotFound();
            }

            return Ok(matHang);
        }

        // PUT: api/MatHangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatHang(Guid id, MatHang matHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matHang.Id)
            {
                return BadRequest();
            }

            db.Entry(matHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatHangExists(id))
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

        // POST: api/MatHangs
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult PostMatHang(MatHang matHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.matHangs.Add(matHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = matHang.Id }, matHang);
        }

        // DELETE: api/MatHangs/5
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult DeleteMatHang(Guid id)
        {
            MatHang matHang = db.matHangs.Find(id);
            if (matHang == null)
            {
                return NotFound();
            }

            db.matHangs.Remove(matHang);
            db.SaveChanges();

            return Ok(matHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatHangExists(Guid id)
        {
            return db.matHangs.Count(e => e.Id == id) > 0;
        }
    }
}