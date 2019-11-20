using System;
using System.Collections.Generic;

namespace Fonebook
{
    public enum DataStructureType
    {
        LinkedList,
        List,
        Dictionary,
        AVLTreeMap,
        RedBlackTreeMap,
        
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var contactsSmall = GetContactsFromFile("contacts_small_50.csv");
            var queriesSmall = GetQueriesFromFile("queries_small_100.csv");
            // ... 
            IFonebook listFonebook = new ListFonebook();
            CreateFonebook(listFonebook, contactsSmall);
            QueryFonebook(listFonebook, queriesSmall);

            listFonebook.Clear();
            var contactsMedium = GetContactsFromFile("contacts_medium_5000.csv");
            var queriesMedium = GetQueriesFromFile("queries_medium_10000.csv");

            IFonebook dictionaryFonebook = new DictionaryFonebook();
            CreateFonebook(dictionaryFonebook, contactsSmall);
            QueryFonebook(dictionaryFonebook, queriesSmall);
        }

        public static List<Contact> GetContactsFromFile(string fileName)
        {
            return null;
        }

        public static List<string> GetQueriesFromFile(string fileName)
        {
            return null;
        }

        public static void CreateFonebook(IFonebook fonebook, List<Contact> contacts)
        {
            // Time creation of fonebook
            // start stop watch

            fonebook.AddAll(contacts);

            // end stop watch
        }

        public static void QueryFonebook(IFonebook fonebook, List<string> names)
        {
            // Time querying of fonebook
            // start stop watch

            var results = fonebook.FindAll(names);

            // end stop watch

        }

    }
}
