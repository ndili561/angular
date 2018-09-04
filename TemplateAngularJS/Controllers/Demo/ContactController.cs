using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateAngularJS.Models.Demo;
using TemplateAngularJS.Repositories.Demo;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemplateAngularJS.Controllers.Demo
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IDemoRepository _demoRepository;
        public ContactController(IDemoRepository demoRepository)
        {
            _demoRepository = demoRepository;
        }
        // GET: /<controller>/
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Demo/Contacts.cshtml");
        }

        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetContacts()
        {
            List<Contact> l = await _demoRepository.GetContacts();
            return Json(l);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddContact([FromBody] Contact c)
        {
            var contact = await _demoRepository.AddContact(c);
            return Json(contact);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact c)
        {
            await _demoRepository.EditContact(c);
            return Json("");
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _demoRepository.GetContactById(id);
            return Json(contact);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteContact([FromBody]Contact c)
        {
            await _demoRepository.DeleteContact(c.ContactId);
            return Json("");
        }
    }
}
