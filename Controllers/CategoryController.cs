using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger,ICategoryService service)
        {
            _logger = logger;
            categoryService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            categoryService.Save(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            categoryService.Update(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Error();
        }
    }
}