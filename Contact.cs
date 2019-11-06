using System;
namespace Fonebook
{
    public class Contact : IComparable<Contact>, IEquatable<Contact>
    {
        // Unique ID
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        public Contact()
        {
        }

        public int CompareTo(Contact other)
        {
            return string.Compare((FirstName + LastName), other.FirstName + other.LastName, StringComparison.CurrentCulture);
        }

        public bool Equals(Contact other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
