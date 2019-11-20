using System;
using System.Collections.Generic;

namespace Fonebook
{
    public class Program
    {
        static void Main(string[] args)
        {
            var contactsSmall = GetContactsFromFile("../../../Data/contacts_small_50.csv");
            var queriesSmall = GetQueriesFromFile("../../../Data/queries_small_100.csv");

            var contactsMedium = GetContactsFromFile("../../../Data/contacts_medium_5000.csv");
            var queriesMedium = GetQueriesFromFile("../../../Data/queries_medium_10000.csv");

            var contactsLarge = GetContactsFromFile("../../../Data/contacts_large_34000.csv");
            var queriesLarge = GetQueriesFromFile("../../../Data/queries_large_68000.csv");

            /* List Fonebook */
            IFonebook listFonebook = new ListFonebook();
            CreateFonebook(listFonebook, contactsSmall);
            QueryFonebook(listFonebook, queriesSmall);

            listFonebook.Clear();
            CreateFonebook(listFonebook, contactsMedium);
            QueryFonebook(listFonebook, queriesMedium);

            listFonebook.Clear();
            CreateFonebook(listFonebook, contactsLarge);
            QueryFonebook(listFonebook, queriesLarge);


            /* Dictionary Fonebook */
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
