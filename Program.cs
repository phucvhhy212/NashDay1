﻿using System.Diagnostics;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var members = GetAll();
            do
            {
                Console.WriteLine("**********************************************************************************************");
                Console.WriteLine("1. Return a list of members who is Male");
                Console.WriteLine("2. Return the oldest one based on Age");
                Console.WriteLine("3. Return a new list that contains Full Name only ( Full Name = Last Name + First Name)");
                Console.WriteLine("4. Return 3 lists: birth year is 2000/birth year greater than 2000/birth year less than 2000");
                Console.WriteLine("5. Return the first person who was born in Ha Noi.");
                Console.WriteLine("6. Print prime number in range");
                Console.WriteLine("7. Exit");
                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        AllMaleMembers(members);
                        break;
                    case 2:
                        OldestMember(members);
                        break;
                    case 3:
                        GetFullName(members);
                        break;
                    case 4:
                        GetListsAge(members);
                        break;
                    case 5:
                        FirstBornHaNoi(members);
                        break;
                    case 6:
                        PrintPrimeNumber();
                        break;
                    case 7: 
                        return;
                    default:
                        Console.WriteLine("Input invalid");
                        break;
                }
            } while (true);
        }

        private static async Task PrintPrimeNumber()
        {
            var tasks = new List<Task>();
            int from = 0;
            int to = 0;
            do
            {
                Console.Write("From: ");
                string fromString = Console.ReadLine();
                try
                {

                    if (!int.TryParse(fromString, out from))
                    {
                        Console.WriteLine("Input invalid");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input invalid {e.Message}");
                }
            } while (true);

            do
            {
                Console.Write("To: ");
                string toString = Console.ReadLine();
                try
                {
                    if(!int.TryParse(toString, out to))
                    {
                        Console.WriteLine("Input invalid");
                        continue;
                    }
                    if (from > to)
                    {
                        Console.WriteLine("Input invalid");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input invalid {e.Message}");
                }
            } while (true);
            Stopwatch syncStopwatch = Stopwatch.StartNew();
            for (int i = from; i <= to; i++)
            {
                var i1 = i;
                tasks.Add(Task.Run(() =>
                {
                    if (IsPrimeNumber(number: i1))
                    {
                        Console.WriteLine(i1);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            syncStopwatch.Stop();
            Console.WriteLine($"Thời gian thực hiện async: {syncStopwatch.ElapsedMilliseconds} ms");
            
            syncStopwatch.Start();
            for (int i = from; i <= to; i++)
            {
                if (IsPrimeNumber(number: i))
                {
                    Console.WriteLine(i);
                }

            }
            syncStopwatch.Stop();
            Console.WriteLine($"Thời gian thực hiện sync: {syncStopwatch.ElapsedMilliseconds} ms");
        }


        private static bool IsPrimeNumber(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            if (number <= 3)
            {
                return true;
            }
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static List<Member> GetAll()
        {
            return new List<Member>
            {
                new Member
                {
                    FirstName = "Huy1",
                    LastName = "Phuc1",
                    BirthPlace = "Ha Noi",
                    DateOfBirth = DateTime.Today,
                    Gender = "Female",
                    IsGraduated = false,
                    PhoneNumber = "7329074222"
                },
                new Member
                {
                    FirstName = "Huy2",
                    LastName = "Phuc2",
                    BirthPlace = "HN",
                    DateOfBirth = DateTime.Parse("2000-11-02"),
                    Gender = "Male",
                    IsGraduated = false,
                    PhoneNumber = "7329074222"
                },
                new Member
                {
                    FirstName = "Huy3",
                    LastName = "Phuc3",
                    BirthPlace = "Ha Noi",
                    DateOfBirth = DateTime.Parse("2000-12-02"),
                    Gender = "Male",
                    IsGraduated = false,
                    PhoneNumber = "7329074222"
                },
                new Member
                {
                    FirstName = "Huy4",
                    LastName = "Phuc4",
                    BirthPlace = "Ha Noi",
                    DateOfBirth = DateTime.Parse("1999-12-02"),
                    Gender = "Male",
                    IsGraduated = false,
                    PhoneNumber = "7329074222"
                }
            };
        }

        private static int GetChoice()
        {
            do
            {
                int choice;
                try
                {
                    Console.Write("Enter choice: ");
                    string inputChoice = Console.ReadLine();
                    choice = int.Parse(inputChoice);
                    if (choice <= 0 || choice > 7)
                    {
                        Console.WriteLine("Input invalid");
                        continue;
                    }

                    return choice;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Input invalid: {e.Message}");
                }
            } while (true);
        }

        private static void FirstBornHaNoi(List<Member> members)
        {
            Console.WriteLine("First person who was born in Ha Noi:");
            var mem = members.FirstOrDefault(x => x.BirthPlace == "Ha Noi");
            Console.WriteLine(mem);
        }

        private static void GetListsAge(List<Member> members)
        {
            Console.WriteLine("Birth year greater than 2000:");
            foreach (var member in members.Where(x => x.DateOfBirth.Year > 2000))
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("Birth year less than 2000:");
            foreach (var member in members.Where(x => x.DateOfBirth.Year < 2000))
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("Birth year equal 2000:");
            foreach (var member in members.Where(x => x.DateOfBirth.Year == 2000))
            {
                Console.WriteLine(member);
            }
        }

        private static void GetFullName(List<Member> members)
        {
            Console.WriteLine("By full name:");
            foreach (var fullName in members.Select(x => x.FullName))
            {
                Console.WriteLine(fullName);
            }
        }

        private static void OldestMember(List<Member> members)
        {
            Console.WriteLine("Oldest one:");
            var target = members.FirstOrDefault(m => DateTime.Now.Year - m.DateOfBirth.Year == members.Max(x => DateTime.Now.Year - x.DateOfBirth.Year));
            Console.WriteLine(target);
        }

        private static void AllMaleMembers(List<Member> members)
        {
            Console.WriteLine("All male mem:");
            foreach (var member in members.Where(x => x.Gender == "Male"))
            {
                Console.WriteLine(member);
            }
        }


    }
}
