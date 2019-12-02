using System;
using System.Collections.Generic;
using DataStructures.Trees;

namespace Fonebook.DataStructures
{
    public class TrieMapFonebook: IFonebook
    {

        private TrieMap<List<Contact>> contactsByFirstName;
        private TrieMap<List<Contact>> contactsByLastName;
        private TrieMap<Contact> contactsById;

        public TrieMapFonebook()
        {
            contactsByFirstName = new TrieMap<List<Contact>>();
            contactsByLastName = new TrieMap<List<Contact>>();
            contactsById = new TrieMap<Contact>();
        }

        public int Size => throw new NotImplementedException();

        public void Add(Contact contact)
        {
            // First name
            if (contactsByFirstName.ContainsWord(contact.FirstName))
            {
                // get the existing list
                List<Contact> list;
                contactsByFirstName.SearchByWord(contact.FirstName, out list);
                // add this contact to the list
                list.Add(contact);

            }
            else
            {
                var list = new List<Contact>();
                list.Add(contact);
                contactsByFirstName.Add(contact.FirstName, list);
            }



        }

        public IFonebook AddAll(List<Contact> contacts)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
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
