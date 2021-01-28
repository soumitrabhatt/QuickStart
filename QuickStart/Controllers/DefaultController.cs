using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStart.Controllers
{
    [ApiController]
    [Route("")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger?? throw new ArgumentNullException(nameof(ILogger));
        }

        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Up" };
            _logger.LogInformation($"Status pinged: {responseObject.Status}");
            return responseObject;
        }

        [HttpPost]
        public object Post(string data)
        {
            data = "Just DaTA- " + data;
            _logger.LogInformation($"data is logged : {data}");
            return new {Data= data };

        }
    }
}
//https://medium.com/imaginelearning/asp-net-core-3-1-microservice-quick-start-c0c2f4d6c7fa