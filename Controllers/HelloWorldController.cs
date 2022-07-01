using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {       
       IHelloWordService helloworldService;
       private readonly ILogger<HelloWorldController> _logger;
       public HelloWorldController(IHelloWordService helloWord, ILogger<HelloWorldController> logger)
       {         
          _logger = logger; 
          _logger.LogInformation("Creating the injection");
          helloworldService = helloWord;
       }  

      [HttpGet]
       public IActionResult Get()
       {
            return Ok(helloworldService.GetHelloWorld());
       }     
    }
}