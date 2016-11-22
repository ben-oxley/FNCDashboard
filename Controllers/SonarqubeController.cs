using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fncdashboard;

namespace Fncdashboard.Controllers
{
    

    
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IOptions<Sonarqube> config;

        public SampleDataController(IOptions<Sonarqube> optionsAccessor)
        {
            this.config = config;
        }

        // GET: /<controller>/
        public IActionResult Index() => View(config.Value);

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Project> Projects()
        {
            return Enumerable.Range(1, 5).Select(index => new Project
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class Project
        {
            public string DateFormatted { get; set; }
            public int LoC { get; set; }
            public int Issues { get; set; }
        }
    }
}
