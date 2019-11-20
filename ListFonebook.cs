using System;
using System.Collections.Generic;

namespace Fonebook
{
    public class ListFonebook: IFonebook
    {
        private List<Contact> contacts = new List<Contact>();

        public ListFonebook()
        {
          
        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        public IFonebook AddAll(List<Contact> contacts)
        {
            foreach(var c in contacts)
            {
                this.Add(c);
            }

            return this;
        }

        public List<Contact> Find(string query)
        {
            var results = contacts.FindAll(
                c => c.FirstName.Equals(query) || c.LastName.Equals(query));

            return results;
        }

        public List<List<Contact>> FindAll(List<string> queries)
        {
            var results = new List<List<Contact>>();

            foreach ( var query in queries)
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

        public Contact Find(int id)
        {
            var result = contacts.Find(c => c.ID == id);

            return result;
        }

        public void Clear()
        {
            contacts.Clear();
        }

        public int Size => contacts.Count;
    }
}
