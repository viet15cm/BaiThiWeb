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
    [RoutePrefix("SanPhams")]
    public class SanPhamsController : ApiController
    {
        private DBcontextLayer db = new DBcontextLayer();

        // GET: api/SanPhams
        [Route("")]
        public ICollection<SanPham> GetsanPhams()
        {
            var c = db.sanPhams.ToList();
            return db.sanPhams.ToList();
        }

        // GET: api/SanPhams/5
        [Route("GetSanPham/{id}")]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(Guid id)
        {
            SanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }

        // PUT: api/SanPhams/5
        [Route("PutSanPham/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(Guid id, SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham.Id)
            {
                return BadRequest();
            }

            db.Entry(sanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
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

        // POST: api/SanPhams
        [Route("PostSanPham")]
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult PostSanPham(SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sanPhams.Add(sanPham);
            db.SaveChanges();

            return Ok(sanPham);
        }

        // DELETE: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult DeleteSanPham(Guid id)
        {
            SanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            db.sanPhams.Remove(sanPham);
            db.SaveChanges();

            return Ok(sanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(Guid id)
        {
            return db.sanPhams.Count(e => e.Id == id) > 0;
        }
    }
}