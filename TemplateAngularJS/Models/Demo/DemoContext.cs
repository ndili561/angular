using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateAngularJS.Models.Demo
{
    /// <summary>
    /// Demo Context to access DB 
    /// </summary>
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Contacts DB Set
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

    }
}
