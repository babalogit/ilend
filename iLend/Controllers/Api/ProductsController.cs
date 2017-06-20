﻿using AutoMapper;
using iLend.Models;
using iLend.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace iLend.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/products
        public IHttpActionResult GetProducts()
        {
            return Ok(Mapper.Map<IEnumerable<ProductDto>>(_context.Products.ToList()));
        }

        // GET /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<ProductDto>(product));
        }

        // POST /api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<Recipient>(productDto);

            _context.Recipients.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        // PUT /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _context.Recipients.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/products/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _context.Recipients.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();

            _context.Recipients.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}