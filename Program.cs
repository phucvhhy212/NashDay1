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
                        Task.WaitAll(PrintPrimeNumber());
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
            int from = 0;
            int to = 0;
            do
            {
                Console.Write("From: ");
                string fromString = Console.ReadLine();
                try
                {
                    int.TryParse(fromString, out from);
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
                    int.TryParse(toString, out to);
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

            for (int i = from; i <= to; i++)
            {
                if (IsPrimeNumber(number: i))
                {
                    await Task.Delay(100);
                    Console.WriteLine(i);
                }
            }
        }


        private static bool IsPrimeNumber(int number)
        {
            bool check = true;
            if(number < 2) return false;
            if(number == 3) return true;
            if(number == 4) return false;
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return check;
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
            while (true)
            {
                //foreach (var member in members)
                //{
                //    if (member.BirthPlace == "Ha Noi")
                //    {
                //        Console.WriteLine(member);
                //        break;
                //    }
                //}
                var mem = members.FirstOrDefault(x => x.BirthPlace == "Ha Noi");
                Console.WriteLine(mem);
                break;
            }
        }

        private static void GetListsAge(List<Member> members)
        {
            var equal = new List<Member>();
            var greater = new List<Member>();
            var less = new List<Member>();
            foreach (var member in members)
            {
                var birthYear = member.DateOfBirth.Year;
                switch (birthYear)
                {
                    case var i when i > 2000:
                        greater.Add(member);
                        break;
                    case var i when i < 2000:
                        less.Add(member);
                        break;
                    default:
                        equal.Add(member);
                        break;

                }
            }

            Console.WriteLine("Birth year greater than 2000:");
            foreach (var member in greater)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("Birth year less than 2000:");
            foreach (var member in less)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("Birth year equal 2000:");
            foreach (var member in equal)
            {
                Console.WriteLine(member);
            }
        }

        private static void GetFullName(List<Member> members)
        {
            Console.WriteLine("By full name:");
            var fullNames = members.Select(x => x.FullName);
            foreach (var fullName in fullNames)
            {
                Console.WriteLine(fullName);
            }
        }

        private static void OldestMember(List<Member> members)
        {
            Console.WriteLine("Oldest one:");
            //var oldestAge = 0;
            //Member target = new Member();
            //foreach (var member in members)
            //{
            //    if (DateTime.Now.Year - member.DateOfBirth.Year > oldestAge)
            //    {
            //        target = member;
            //        oldestAge = member.Age;
            //    }
            //}
            var target = members.FirstOrDefault(m => DateTime.Now.Year - m.DateOfBirth.Year == members.Max(x => DateTime.Now.Year - x.DateOfBirth.Year));
            Console.WriteLine(target);
        }

        private static void AllMaleMembers(List<Member> members)
        {
            Console.WriteLine("All male mem:");
            var males = members.Where(x => x.Gender == "Male");
            foreach (var member in males)
            {
                Console.WriteLine(member);
            }
        }


    }
}
