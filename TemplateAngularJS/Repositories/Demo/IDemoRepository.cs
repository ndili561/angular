
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateAngularJS.Models.Demo;

namespace TemplateAngularJS.Repositories.Demo
{
    public interface IDemoRepository
    {
        /// <summary>
        /// Gets contacts list 
        /// </summary>
        /// <returns></returns>
        Task<List<Contact>> GetContacts();

        /// <summary>
        /// Adds new contact to DB
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        Task<Contact> AddContact(Contact c);


        /// <summary>
        /// Gets a contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Contact> GetContactById(int id);

        /// <summary>
        /// Updates a contact 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        Task EditContact(Contact c);


        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteContact(int id);
       
    }
}
