using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToyStore.IDataAccess;
using ToyStore.Model;
using ToyStore.WebApp.Models;

namespace ToyStore.WebApp.Controllers
{
    /// <summary>
    /// Controller for products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductForListModel>> Get()
        {
            return Ok(_productRepository
                        .GetAll()
                        .Select(_mapper.Map<Product, ProductForListModel>));
        }

        [HttpGet("Id")]
        public ActionResult<Product> GetById(int id)
        {
            return Ok(_productRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult<Product> Create(NewProductModel product)
        {
            try
            {
                return Ok(_productRepository
                    .Create(_mapper.Map<NewProductModel, Product>(product)));
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int productId)
        {
            _productRepository.Delete(productId);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Product> Edit(UpdateProductModel product)
        {
            try
            {
                var response = _productRepository
                    .Update(_mapper.Map<UpdateProductModel,Product>(product));
                if (product != null)
                    return Ok(response);
                else
                    return NotFound();
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}