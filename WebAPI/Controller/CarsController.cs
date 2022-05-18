using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public List<Car> Get()
        {
            return new List<Car>
            {
                new Car{CarId=1, CarName="Audi"},
                new Car{CarId=2, CarName="Porsche"},

            };
        }
    }
}
