using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebTechTest.Models.Test1;
using WebTechTest.Services;

namespace WebTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test1Controller : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dataContext;

        public Test1Controller(ILogger<WeatherForecastController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet(Name = "GetPeople")]
        public IEnumerable<Person> GetPeople()
        {
            var persons = _dataContext.People.Include(n => n.PersonAdGroups).ThenInclude(n => n.AdGroup)
                                .OrderBy(n => n.Surname)
                                .ThenBy(n => n.Name)
                                .ToList();
            return persons;
        }

    }
}
