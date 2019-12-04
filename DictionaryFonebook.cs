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
        }

        public int Size => contactsById.Count;

        public void Add(Contact contact)
        {
            // Add by first name
            if (contactsByFirstName.ContainsKey(contact.FirstName))
            {
                contactsByFirstName[contact.FirstName].Add(contact);
            }
            else
            {
                contactsByFirstName[contact.FirstName] = new List<Contact>();
                contactsByFirstName[contact.FirstName].Add(contact);
            }

            // Add by last name
            if (contactsByLastName.ContainsKey(contact.LastName))
            {
                contactsByLastName[contact.LastName].Add(contact);
            }
            else
            {
                contactsByLastName[contact.LastName] = new List<Contact>();
                contactsByLastName[contact.LastName].Add(contact);
            }

            // Add by Id
            if (contactsById.ContainsKey(contact.ID))
            {
                throw new Exception("Contact IDs must be unique.");
            }
            else
            {
                contactsById[contact.ID] = contact;
            }
            
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
            contactsByFirstName.Clear();
            contactsByLastName.Clear();
            contactsById.Clear();
        }

        public List<Contact> Find(string query)
        {
            var results = new List<Contact>();

            // get first name matches
            if (contactsByFirstName.ContainsKey(query))
            {
                results.AddRange(contactsByFirstName[query]);
            }
            
            // get last name matches
            if (contactsByLastName.ContainsKey(query) )
            {
                results.AddRange(contactsByLastName[query]);
            }

            return results;
        }

        public Contact Find(int id)
        {
            return contactsById[id];
        }

        public List<List<Contact>> FindAll(List<string> queries)
        {
            var results = new List<List<Contact>>();

            foreach(var query in queries)
            {
                results.Add(Find(query));
            }

            return results;
        }

        public List<Contact> FindAll(List<int> ids)
        {
            var results = new List<Contact>();

            foreach (var id in ids)
            {
                results.Add(Find(id));
            }

            return results;
        }
    }
}
