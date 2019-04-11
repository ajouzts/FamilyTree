using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public enum Sex { Male, Female, None }

    public class Person
    {
        public readonly int RefNum;
        public string FirstName { get; set; }
        public Person Spouse { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set;}
        public List<Person> Children { get; set; }
        public Sex PersonSex { get; set; }

        public Person()
        {
            FirstName = "Unknown";
            Spouse = null;
            Father = null;
            Mother = null;
            Children = new List<Person>();
            PersonSex = (Sex)2;
            RefNum = RandomNumber(0, 1000);
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public bool HasChildren()
        {
            if (Children.Count == 0)
                return false;
            return true;
        }

        public bool HasFather()
        {
            if (Father == null)
                return false;
            return true;
        }

        public bool HasSpouse()
        {
            if (Spouse == null)
                return false;
            return true;
        }

        public bool HasMother()
        {
            if (Mother == null)
                return false;
            return true;
        }
    }
}
