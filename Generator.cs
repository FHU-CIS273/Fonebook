using System.Collections.Generic;
using System.IO;
using System;

namespace Fonebook
{
    public class Generator
    {
        public enum Size { small, medium, large }
        public static void MakeQueries()
        {
            MakeQuery(Size.small);
            MakeQuery(Size.medium);
            MakeQuery(Size.large);
        }

        public static void MakeRandomQueries()
        {
            MakeRandomQuery(Size.small);
            MakeRandomQuery(Size.medium);
            MakeRandomQuery(Size.large);
        }

        private static void MakeQuery(Size size)
        {
            string nameQueryPath;
            string idQueryPath;

            switch (size)
            {
                case Size.small:
                    nameQueryPath = "../../../Data/queries_small_100.csv";
                    idQueryPath = "../../../Data/queries_id_small_100.csv";
                    break;
                case Size.medium:
                    nameQueryPath = "../../../Data/queries_medium_10000.csv";
                    idQueryPath = "../../../Data/queries_id_medium_10000.csv";
                    break;
                case Size.large:
                    nameQueryPath = "../../../Data/queries_large_68000.csv";
                    idQueryPath = "../../../Data/queries_id_large_68000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> first = GetFirstNameList(size);
            List<string> last = GetLastNameList(size);
            List<int> ids = GetIDList(size);

            using (StreamWriter streamWriter = new StreamWriter(nameQueryPath))
            {
                foreach(string name in first)
                {
                    streamWriter.WriteLine(name);
                }
                foreach (string name in last)
                {
                    streamWriter.WriteLine(name);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(idQueryPath))
            {
                foreach (int id in ids)
                {
                    streamWriter.WriteLine(id);
                }
            }

        }

        private static void MakeRandomQuery(Size size)
        {
            string nameQueryPath;
            string idQueryPath;

            int querySize = 0;
            switch (size)
            {
                case Size.small:
                    nameQueryPath = "../../../Data/queries_small_100.csv";
                    idQueryPath = "../../../Data/queries_id_small_100.csv";
                    querySize = 100;
                    break;
                case Size.medium:
                    nameQueryPath = "../../../Data/queries_medium_10000.csv";
                    idQueryPath = "../../../Data/queries_id_medium_10000.csv";
                    querySize = 10000;
                    break;
                case Size.large:
                    nameQueryPath = "../../../Data/queries_large_68000.csv";
                    idQueryPath = "../../../Data/queries_id_large_68000.csv";
                    querySize = 68000;
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> first = GetFirstNameList(size);
            List<string> last = GetLastNameList(size);
            List<int> ids = GetIDList(size);
            Random random = new Random();
            int index = 0;

            /*using (StreamWriter streamWriter = new StreamWriter(nameQueryPath))
            {
                for (int i = 0; i < querySize; i++)
                {
                    index = random.Next() % first.Count;
                    streamWriter.WriteLine(first[index]);
                    index = random.Next() % last.Count;
                    streamWriter.WriteLine(last[index]);
                }
            }*/

            using (StreamWriter streamWriter = new StreamWriter(idQueryPath))
            {
                for (int i = 0; i < querySize; i++)
                {
                    index = random.Next() % ids.Count;
                    streamWriter.WriteLine(ids[index]);
                }
            }
        }

        private static List<string> GetFirstNameList(Size size)
        {
            int querySize;
            string path;
            switch(size)
            {
                case Size.small:
                    querySize = 50;
                    path = "../../../Data/contacts_small_50.csv";
                    break;
                case Size.medium:
                    querySize = 5000;
                    path = "../../../Data/contacts_medium_5000.csv";
                    break;
                case Size.large:
                    querySize = 34000;
                    path = "../../../Data/contacts_large_34000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> list = new List<string>();
            using (StreamReader streamReader = File.OpenText(path))
            {
                string text = streamReader.ReadToEnd();

                //Console.WriteLine(text);

                var lines = text.Split(System.Environment.NewLine);
                for (int i = 1; i < querySize + 1; i++)
                {
                    var words = lines[i].Split(",");
                    list.Add(words[1]);
                }
                
            }
            return list;
        }

        private static List<string> GetLastNameList(Size size)
        {
            int querySize;
            string path;
            switch (size)
            {
                case Size.small:
                    querySize = 50;
                    path = "../../../Data/contacts_small_50.csv";
                    break;
                case Size.medium:
                    querySize = 5000;
                    path = "../../../Data/contacts_medium_5000.csv";
                    break;
                case Size.large:
                    querySize = 34000;
                    path = "../../../Data/contacts_large_34000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> list = new List<string>();
            using (StreamReader streamReader = File.OpenText(path))
            {
                string text = streamReader.ReadToEnd();

                //Console.WriteLine(text);

                var lines = text.Split(System.Environment.NewLine);
                for (int i = 1; i < querySize + 1; i++)
                {
                    var words = lines[i].Split(",");
                    list.Add(words[2]);
                }

            }
            return list;
        }

        private static List<int> GetIDList(Size size)
        {
            int querySize;
            string path;
            switch (size)
            {
                case Size.small:
                    querySize = 50;
                    path = "../../../Data/contacts_small_50.csv";
                    break;
                case Size.medium:
                    querySize = 5000;
                    path = "../../../Data/contacts_medium_5000.csv";
                    break;
                case Size.large:
                    querySize = 34000;
                    path = "../../../Data/contacts_large_34000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }

            List<int> list = new List<int>();
            using (StreamReader streamReader = File.OpenText(path))
            {
                string text = streamReader.ReadToEnd();

                //Console.WriteLine(text);

                var lines = text.Split(System.Environment.NewLine);
                for (int i = 1; i < querySize + 1; i++)
                {
                    var words = lines[i].Split(",");
                    list.Add(int.Parse(words[0]));
                }

            }
            return list;
        }
    }
}