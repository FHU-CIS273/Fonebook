using System;
using System.Collections.Generic;

namespace Fonebook
{
    public class Program
    {
        static void Main(string[] args)
        {

            var contactsSmall = GetContactsFromFile("../../../Data/contacts_small_50.csv");
            var nameQueriesSmall = GetNameQueriesFromFile("../../../Data/queries_small_100.csv");
            var idQueriesSmall = GetIDQueriesFromFile("../../../Data/queries_id_small_100.csv");

            var contactsMedium = GetContactsFromFile("../../../Data/contacts_medium_5000.csv");
            var queriesMedium = GetNameQueriesFromFile("../../../Data/queries_medium_10000.csv");
            var idQueriesMedium = GetIDQueriesFromFile("../../../Data/queries_id_medium_10000.csv");

            var contactsLarge = GetContactsFromFile("../../../Data/contacts_large_34000.csv");
            var queriesLarge = GetNameQueriesFromFile("../../../Data/queries_large_68000.csv");
            var idQueriesLarge = GetIDQueriesFromFile("../../../Data/queries_id_large_68000.csv");


            /* List Fonebook */
            IFonebook listFonebook = new ListFonebook();
            CreateFonebook(listFonebook, contactsSmall);
            QueryFonebook(listFonebook, nameQueriesSmall);
            QueryFonebook(listFonebook, idQueriesSmall);

            listFonebook.Clear();
            CreateFonebook(listFonebook, contactsMedium);
            QueryFonebook(listFonebook, queriesMedium);
            QueryFonebook(listFonebook, idQueriesMedium);

            listFonebook.Clear();
            CreateFonebook(listFonebook, contactsLarge);
            QueryFonebook(listFonebook, queriesLarge);
            QueryFonebook(listFonebook, idQueriesLarge);

            /* Dictionary Fonebook */
            IFonebook dictionaryFonebook = new DictionaryFonebook();
            CreateFonebook(dictionaryFonebook, contactsSmall);
            QueryFonebook(dictionaryFonebook, nameQueriesSmall);
            QueryFonebook(dictionaryFonebook, idQueriesSmall);

            // Repeat for medium and large data sets
        }

        public static List<Contact> GetContactsFromFile(string fileName)
        {
            return null;
        }

        public static List<string> GetNameQueriesFromFile(string fileName)
        {
            return null;
        }

        public static List<int> GetIDQueriesFromFile(string fileName)
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

        public static void QueryFonebook(IFonebook fonebook, List<int> ids)
        {
            // Time querying of fonebook
            // start stop watch

            var results = fonebook.FindAll(ids);

            // end stop watch

        }

    }
}
