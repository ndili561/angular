using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateAngularJS.Models.Demo;

namespace TemplateAngularJS.Repositories.Demo
{
    /// <summary>
    /// Demo repository
    /// </summary>
    public class DemoRepository : IDemoRepository
    {
        /// <summary>
        /// Demo DbContext
        /// </summary>
        private DemoContext _demoContext;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="demoContext"></param>
        public DemoRepository(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        /// <summary>
        /// Gets contacts list 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                return await _demoContext.Contacts.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Adds new contact to DB
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<Contact> AddContact(Contact c)
        {
            try
            {
                await _demoContext.AddAsync(c);
                await _demoContext.SaveChangesAsync();
                return c;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets a contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Contact> GetContactById(int id)
        {
            try
            {
               return await _demoContext.Contacts.FirstOrDefaultAsync(v => v.ContactId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates a contact 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task EditContact(Contact c)
        {
            try
            {
                var contact = await _demoContext.Contacts.FirstOrDefaultAsync(v => v.ContactId == c.ContactId);

                contact.Email = c.Email;
                contact.Name = c.Name;
                contact.Phone = c.Phone;

                 _demoContext.Update(contact);
                await _demoContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteContact(int id)
        {
            try
            {
                var contact = await _demoContext.Contacts.FirstOrDefaultAsync(v => v.ContactId== id);
                _demoContext.Remove(contact);
                await _demoContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
