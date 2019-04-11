using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTree;

namespace MyApp
{
    class Program
    {
        public static void MainUI()
        {
            Clan fam = new Clan();
            Console.WriteLine("Welcome to the Geneology Program");
            Console.Write("\nPlease give a name for the family name: ");
            fam.ClanName = Console.ReadLine();

            
            while(true)
            {
                int decision;

                Console.WriteLine("{0}'s Family", fam.ClanName);
                Console.WriteLine("1.\t\tPrint Family Members");
                Console.WriteLine("2.\t\tPrint a Family Member");
                Console.WriteLine("3.\t\tAdd a Family Member");
                Console.WriteLine("4.\t\tEdit a Family Member");
                Console.WriteLine("5.\t\tDelete a Family Member");
                Console.WriteLine("6.\t\tTotal Members in Family");
                Console.WriteLine("7.\t\tExit");
                Console.Write("\n\nYour selection: ");
                decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        {
                            fam.PrintClan();
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 2:
                        {
                            fam.PrintPerson();
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 3:
                        {
                            fam.AddPerson();
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 4:
                        {
                            fam.EditPerson();
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 5:
                        {
                            fam.DeletePerson();
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Number of members: {0}", fam.getMembers());
                            Console.WriteLine("\n\n");
                            break;
                        }
                    case 7:
                        {
                            System.Environment.Exit(1);
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

        static void Main(string[] args)
        {
            MainUI();
            Console.Read();
        }
    }
}
