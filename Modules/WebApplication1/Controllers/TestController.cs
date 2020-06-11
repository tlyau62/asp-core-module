using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnityAddon.Core.Attributes;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [PostConstruct]
        public void Init()
        {
            var a = 10;
        }

        [HttpGet]
        public string Get()
        {
            return "TestString";
        }
    }
}
