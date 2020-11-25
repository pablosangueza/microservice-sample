using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sales.Microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private static readonly string[] customersArray = new[]
        {
            "Juan Pablo", "Daniel", "Laura", "Salma", "Alejandra", "Victor", "Lukas", "Franz"
        };
        private static readonly string[] CompaniesArray = new[]
        {
            "NICE InContact", "AssureSoft", "Trueextend", "JalaSoft", "Google", "Feacebok"
        };

        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Customer
            {
                LastBought = DateTime.Now.AddDays(index),
                Company = CompaniesArray[rng.Next(CompaniesArray.Length)],
                Name = customersArray[rng.Next(customersArray.Length)]
            })
            .ToArray();
        }
    }
}
