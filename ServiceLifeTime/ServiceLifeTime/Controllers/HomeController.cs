using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Models;
using ServiceLifeTime.Services;

namespace ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService scopedService01;
        private readonly IScopedService scopedService02;
        private readonly ITransientService transientService01;
        private readonly ITransientService transientService02;
        private readonly ISingletonService singletonService01;
        private readonly ISingletonService singletonService02;

        public HomeController(ILogger<HomeController> logger
            ,IScopedService scopedService01 ,
             IScopedService scopedService02,
             ITransientService transientService01,
             ITransientService transientService02,
             ISingletonService singletonService01,
             ISingletonService singletonService02)
        {
            _logger = logger;
            this.scopedService01 = scopedService01;
            this.scopedService02 = scopedService02;
            this.transientService01 = transientService01;
            this.transientService02 = transientService02;
            this.singletonService01 = singletonService01;
            this.singletonService02 = singletonService02;
        }

        public string Index()
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine($"scopedService01 = {scopedService01.GetGuid()}"); //C X
            SB.AppendLine($"scopedService02 = {scopedService02.GetGuid()}");//C  X

            SB.AppendLine($"transientService01= {transientService01.GetGuid()}");//A
            SB.AppendLine($"transientService02= {transientService02.GetGuid()}");//B


            SB.AppendLine($"singletonService01= {singletonService01.GetGuid()}");//H H
            SB.AppendLine($"singletonService02= {singletonService02.GetGuid()}");//H H

            return SB.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
