using System;
using System.Collections.Generic;

namespace Fonebook
{
    public interface IFonebook
    {
        IFonebook AddAll(List<Contact> contacts);
        void Add(Contact contact);

        List<List<Contact>> FindAll(List<string> queries);
        List<Contact> Find(string query);

        List<Contact> FindAll(List<int> ids);
        Contact Find(int id);

        void Clear();

        int Size { get; }

    }


}
