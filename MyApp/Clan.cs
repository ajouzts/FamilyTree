using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Clan
    {
        public string ClanName { get; set; }
        public List<Person> ClanMembers { get; set; }
        private int NumberOfMembers;

        public int getMembers()
        {
            return NumberOfMembers;
        }

        public Clan()
        {
            ClanName = "Unknown";
            ClanMembers = new List<Person>();
            NumberOfMembers = 0;
        }

        public void AddPerson()
        {
            Person p = new Person();
            NameChange(p);
            PersonSex(p);

            ClanMembers.Add(p);
            NumberOfMembers++;
        }

        public void DeletePerson()
        {
            PrintClan();

            Console.Write("\n\nType the refernce number of the charcter you would like to delete: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            if (ClanMembers[count].HasSpouse() == true)
            {
                DeleteSpouse(ClanMembers[count]);
            }
            if (ClanMembers[count].HasFather() == true)
            {
                DeleteFather(ClanMembers[count]);
            }
            if (ClanMembers[count].HasMother() == true)
            {
                DeleteMother(ClanMembers[count]);
            }

            RemoveAllChildren(ClanMembers[count]);

            ClanMembers.Remove(ClanMembers[count]);
            NumberOfMembers--;
        }


        public void EditPerson()
        {
            PrintClan();

            Console.Write("\n\nType the refernce number of the charcter you would like to edit: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            bool t = true;
            while (t)
            {
                int decision;

                Console.WriteLine("1.\t\tChange Name");
                Console.WriteLine("2.\t\tChange Sex");
                Console.WriteLine("3.\t\tAdd Spouse");
                Console.WriteLine("4.\t\tAdd Father");
                Console.WriteLine("5.\t\tAdd Mother");
                Console.WriteLine("6.\t\tAdd Child");
                Console.WriteLine("7.\t\tDelete Spouse");
                Console.WriteLine("8.\t\tDelete Father");
                Console.WriteLine("9.\t\tDelete Mother");
                Console.WriteLine("10.\t\tDelete Child");
                //Console.WriteLine("11.\t\tDecendants");
                Console.WriteLine("11.\t\tExit");
                Console.Write("\n\nYour selection: ");

                decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        {
                            NameChange(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 2:
                        {
                            PersonSex(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 3:
                        {
                            AddSpouse(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 4:
                        {
                            AddFather(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 5:
                        {
                            AddMother(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 6:
                        {
                            AddChild(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 7:
                        {
                            DeleteSpouse(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 8:
                        {
                            DeleteFather(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 9:
                        {
                            DeleteMother(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 10:
                        {
                            RemoveChild(ClanMembers[count]);
                            Console.WriteLine("\n\n");
                            break;
                        }
                    //case 11:
                    //    {
                    //        Console.WriteLine("Number of Decendants: {0}",Decendants(ClanMembers[count], 0, 0));
                    //        Console.WriteLine("\n\n");
                    //        break;
                    //    }
                    case 11:
                        {
                            t = false;
                            Console.WriteLine("\n\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input");
                            break;
                        }
                }
            }

        }

        //public int Decendants(Person p, int result, int count)
        //{
        //    if(p.Children.Count == 0)
        //    {
        //        return result;
        //    }
        //    else
        //    {
        //        foreach(Person a in p.Children)
        //        {
        //            result += a.Children.Count;
        //            return Decendants(a, result);
        //        }
        //        return Decendants(p.Children[count], result += p.Children.Count, count++);
        //    }
            
        //}

        public void NameChange(Person p)
        {
            Console.Write("First Name: ");
            p.FirstName = Console.ReadLine();
        }

        public void NameChange()
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to edit: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            Console.Write("First Name: ");
            ClanMembers[count].FirstName = Console.ReadLine();
        }

        public void PersonSex(Person p)
        {
            Console.Write("What is the person's sex (0: Male or 1: Female): ");
            p.PersonSex = (Sex)Convert.ToInt32(Console.ReadLine());
        }

        public void PersonSex()
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to edit: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            Console.Write("What is the person's sex (0: Male or 1: Female): ");
            ClanMembers[count].PersonSex = (Sex)Convert.ToInt32(Console.ReadLine());
        }

        public void PrintClan()
        {
            int count = 0;
            foreach(Person p in ClanMembers)
            {
                Console.WriteLine("Refernce #: {0}\t {1}", ClanMembers[count].RefNum, ClanMembers[count].FirstName);
                count++;
            }
        }

        public void PrintPerson()
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to print: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            Console.WriteLine("\nRefernce #: {0}\t {1}", ClanMembers[count].RefNum, ClanMembers[count].FirstName);

            Console.WriteLine("Sex: \t{0}", ClanMembers[count].PersonSex);
            if (ClanMembers[count].HasSpouse() == true)
            { Console.WriteLine("Spouse: {0}", ClanMembers[count].Spouse.FirstName); }

            if (ClanMembers[count].HasFather() == true)
            { Console.WriteLine("Father: {0}", ClanMembers[count].Father.FirstName); }

            if (ClanMembers[count].HasMother() == true)
                Console.WriteLine("Mother: {0}", ClanMembers[count].Mother.FirstName);

            if (ClanMembers[count].HasChildren() == true)
            {
                int childnum = 0;
                foreach (Person p in ClanMembers[count].Children)
                {
                    Console.WriteLine("Children: {0}", ClanMembers[count].Children[childnum].FirstName);
                    childnum++;
                }
            }

        }

        public void AddSpouse(Person p)
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to add as the spouse: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if(ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }
            ClanMembers[count].Spouse = p; 
            p.Spouse = ClanMembers[count];
        }

        public void DeleteSpouse(Person p)
        {
            int refnum = p.Spouse.RefNum;
            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            ClanMembers[count].Spouse = null;
            p.Spouse = null;
        }

        public void AddMother(Person p)
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to add as the mother: ");
            int refnum = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }
            ClanMembers[count].Children.Add(p);
            p.Mother = ClanMembers[count];
        }

        public void DeleteMother(Person p)
        {
            int refnum = p.Mother.RefNum;

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }
            ClanMembers[count].Children.Remove(p);
            p.Mother = null;
        }

        public void AddFather(Person p)
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to add as the father: ");
            int refnum = Convert.ToInt32(Console.ReadLine());


            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }
            ClanMembers[count].Children.Add(p);
            p.Father = ClanMembers[count];
        }

        public void DeleteFather(Person p)
        {
            int refnum = p.Father.RefNum;

            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            ClanMembers[count].Children.Remove(p);
            p.Father = null;
        }

        public void AddChild(Person p)
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to add as the child: ");
            int refnum = Convert.ToInt32(Console.ReadLine());


            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            p.Children.Add(ClanMembers[count]);

            if(p.PersonSex == (Sex)0)
            {
                ClanMembers[count].Father = p;
            }

            if (p.PersonSex == (Sex)1)
            {
                ClanMembers[count].Mother = p;
            }
        }

        public void RemoveChild(Person p)
        {
            PrintClan();

            Console.WriteLine("\n\nType the refernce number of the charcter you would like to remove as the child: ");
            int refnum = Convert.ToInt32(Console.ReadLine());


            int count = 0;
            while (refnum != 0)
            {
                if (ClanMembers[count].RefNum == refnum)
                {
                    refnum -= ClanMembers[count].RefNum;
                    break;
                }
                count++;
            }

            p.Children.Remove(ClanMembers[count]);

            if (p.PersonSex == (Sex)0)
            {
                ClanMembers[count].Father = null;
            }

            if (p.PersonSex == (Sex)1)
            {
                ClanMembers[count].Mother = null;
            }
        }

        public void RemoveAllChildren(Person p)
        {
            if (p.HasChildren() == true)
            {
                foreach (Person a in p.Children)
                {
                    if (p.PersonSex == (Sex)0)
                    {
                        a.Father = null;
                    }

                    if (p.PersonSex == (Sex)1)
                    {
                        a.Mother = null;
                    }
                }
            }
        }
    }
}
