using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {       
       IHelloWordService helloworldService;
       TaskContext dbContext;
       private readonly ILogger<HelloWorldController> _logger;
       public HelloWorldController(IHelloWordService helloWord, ILogger<HelloWorldController> logger, TaskContext db)
       {         
          _logger = logger; 
          _logger.LogInformation("Creating the injection");
          helloworldService = helloWord;
          dbContext = db;
       }  

      [HttpGet]
       public IActionResult Get()
       {
            return Ok(helloworldService.GetHelloWorld());
       }     

       [HttpGet]
       [Route("createdb")]
       public IActionResult CreateDatabase()
       {
         dbContext.Database.EnsureCreated();
         return Ok();
       }
    }
}