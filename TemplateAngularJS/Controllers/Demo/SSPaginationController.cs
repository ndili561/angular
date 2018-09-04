using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemplateAngularJS.Controllers.Demo
{
    [Route("SSPagination")]
    public class SSPaginationController : Controller
    {
      
        [HttpGet]
        [Route("Index")]
        public IActionResult Pagination()
        {
            return View("~/Views/Demo/Pagination.cshtml");
        }

    }
}
