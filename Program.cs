namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("6. Exit");
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
                        return;
                    default:
                        Console.WriteLine("Input invalid");
                        break;
                }
            } while (true);
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
                    if (choice <= 0 || choice > 6)
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
                foreach (var member in members)
                {
                    if (member.BirthPlace == "Ha Noi")
                    {
                        Console.WriteLine(member);
                        break;
                    }
                }
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
            foreach (var member in members)
            {
                Console.WriteLine(member.FullName);
            }
        }

        private static void OldestMember(List<Member> members)
        {
            Console.WriteLine("Oldest one:");
            var oldestAge = 0;
            Member target = new Member();
            foreach (var member in members)
            {
                if (DateTime.Now.Year - member.DateOfBirth.Year > oldestAge)
                {
                    target = member;
                    oldestAge = member.Age;
                }
            }
            Console.WriteLine(target);
        }

        private static void AllMaleMembers(List<Member> members)
        {
            Console.WriteLine("All male mem:");
            foreach (var member in members)
            {
                if (member.Gender == "Male")
                    Console.WriteLine(member);
            }
        }

        
    }
}
