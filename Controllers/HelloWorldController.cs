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

       public HelloWorldController(IHelloWordService helloWord)
       {
            helloworldService = helloWord;
       }  

       public IActionResult Get()
       {
            return Ok(helloworldService.GetHelloWorld());
       }     
    }
}