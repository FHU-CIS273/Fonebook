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
            string path;
            switch (size)
            {
                case Size.small:
                    path = "../../../Data/queries_small_100.csv";
                    break;
                case Size.medium:
                    path = "../../../Data/queries_medium_10000.csv";
                    break;
                case Size.large:
                    path = "../../../Data/queries_large_68000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> first = GetFirstNameList(size);
            List<string> last = GetLastNameList(size);

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach(string name in first)
                {
                    sw.WriteLine(name);
                }
                foreach (string name in last)
                {
                    sw.WriteLine(name);
                }
            }
        }

        private static void MakeRandomQuery(Size size)
        {
            string path;
            int querySize;
            switch (size)
            {
                case Size.small:
                    querySize = 50;
                    path = "../../../Data/queries_small_100.csv";
                    break;
                case Size.medium:
                    querySize = 5000;
                    path = "../../../Data/queries_medium_10000.csv";
                    break;
                case Size.large:
                    querySize = 34000;
                    path = "../../../Data/queries_large_68000.csv";
                    break;
                default:
                    throw new System.ArgumentException();
            }
            List<string> first = GetFirstNameList(size);
            List<string> last = GetLastNameList(size);
            Random random = new Random();
            int index = 0;

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < querySize; i++)
                {
                    index = random.Next() % querySize;
                    sw.WriteLine(first[index]);
                    index = random.Next() % querySize;
                    sw.WriteLine(last[index]);
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
    }
}