using Microsoft.AspNetCore.Mvc;
using Status.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status.Web.Controllers
{
    public class GetController : Controller
    {
        private readonly IReadingRepository readingRepository;

        public GetController(IReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
        }

        public IActionResult LatestReading()
        {
            return new JsonResult(readingRepository.GetLatestReading());
        }

        public IActionResult LatestHour()
        {
            return new JsonResult(readingRepository.GetReadings(DateTime.Now.AddHours(-1)));
        }
    }
}
