using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateAngularJS.Models.Demo
{
    public class Contact
    {
        [Key]
        public int ContactId { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
    }
}
