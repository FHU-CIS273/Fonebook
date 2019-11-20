using System;
using System.Collections.Generic;

namespace Fonebook
{
    public class DictionaryFonebook: IFonebook
    {
        private Dictionary<string, List<Contact>> contactsByFirstName;
        private Dictionary<string, List<Contact>> contactsByLastName;
        private Dictionary<int, Contact> contactsById;

        public DictionaryFonebook()
        {
            contactsByFirstName = new Dictionary<string, List<Contact>>();
            contactsByLastName = new Dictionary<string, List<Contact>>();
            contactsById = new Dictionary<int, Contact>();
            Size = 0;
        }

        public int Size
        {
            get;set;
        }

        public void Add(Contact contact)
        {
            // Add by first name
            var firstNameMatches = contactsByFirstName[contact.FirstName];
            if (firstNameMatches == null)
            {
                contactsByFirstName[contact.FirstName] = new List<Contact>();
                contactsByFirstName[contact.FirstName].Add(contact);
            }
            else
            {
                firstNameMatches.Add(contact);
            }

            // Add by last name
            var lastNameMatches = contactsByLastName[contact.LastName];
            if (lastNameMatches == null)
            {
                contactsByLastName[contact.LastName] = new List<Contact>();
                contactsByLastName[contact.LastName].Add(contact);
            }
            else
            {
                lastNameMatches.Add(contact);
            }

            // Add by Id
            contactsById[contact.ID] = contact;


            Size++;
        }

        public IFonebook AddAll(List<Contact> contacts)
        {
            foreach( var contact in contacts)
            {
                Add(contact);
            }

            return this;
        }

        public void Clear()
        {
            Size = 0;
            contactsByFirstName.Clear();
            contactsByLastName.Clear();
            contactsById.Clear();
        }

        public List<Contact> Find(string query)
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<List<Contact>> FindAll(List<string> queries)
        {
            throw new NotImplementedException();
        }

        public List<Contact> FindAll(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
