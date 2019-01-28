using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.DAL;

namespace WebAPI.Controllers
{
    
    public class ProductsController : ApiController
    {
        private MCUContext context = new MCUContext();
        // GET api/<controller>
        [Route("api/GetProducts")]
        public IQueryable<Products> GetProducts()
        {
            return context.Products;
        }

        // GET api/<controller>/5
        [Route("api/GetProduct/{ID}")]
        public IHttpActionResult GetProduct(int ID)
        {
            var product = context.Products.Where(t => t.ID == ID).FirstOrDefault();
            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        // POST api/<controller>
        [Route("api/NewProduct")]
        [Authorize(Users="DOMAIN\\UserName")]
        public IHttpActionResult Post([System.Web.Mvc.Bind(Exclude = "product.ID")]Products product)
        {
            
            if (ModelState.ContainsKey("product.ID"))
                ModelState["product.ID"].Errors.Clear();

            if (ModelState.IsValid)
            {
                var exsitingProduct = context.Products.Where(t => t.ProductName == product.ProductName).FirstOrDefault();
                if (exsitingProduct != null)
                {
                    ModelState.AddModelError("ProductName", "This product alreay exists.");
                    return BadRequest(ModelState);
                }
                else
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return Ok();
                }
            }
            else
                return BadRequest(ModelState);
        }

        // PUT api/<controller>/5
        [Route("api/UpdateProduct/{ID}")]
        [Authorize(Users="DOMAIN\\UserName")]
        public IHttpActionResult Put(int ID, Products product)
        {
            if (ModelState.IsValid)
            {
                if (product.ID != ID)
                    return BadRequest();
                try
                {
                    context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return Ok(product);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    bool isexist = context.Products.Count(t => t.ID == ID) > 0;
                    if (!isexist)
                        return NotFound();
                    else
                        return InternalServerError(ex);
                }
            }
            else
                return BadRequest(ModelState);
        }

        // DELETE api/<controller>/5
        [Route("api/DeleteProduct/{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            var product = context.Products.FirstOrDefault(t => t.ID == ID);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                return Ok(product);
            }
            else
                return NotFound();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                context.Dispose();

            base.Dispose(disposing);
        }
    }
}