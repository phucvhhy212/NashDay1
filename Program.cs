namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var members = new List<Member>
            {
                new Member
                {
                    FirstName = "Huy1",
                    LastName = "Phuc1",
                    Age = 15,
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
                    Age = 15,
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
                    Age = 18,
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
                    Age = 18,
                    BirthPlace = "Ha Noi",
                    DateOfBirth = DateTime.Parse("1999-12-02"),
                    Gender = "Male",
                    IsGraduated = false,
                    PhoneNumber = "7329074222"
                }
            };

            Console.WriteLine("All male mem:");
            foreach (var member in members)
            {
                if(member.Gender == "Male")
                    Console.WriteLine(member);
            }
            Console.WriteLine("========================");
            Console.WriteLine("Oldest one:");
            var oldestAge = 0;
            Member target = new Member();
            foreach (var member in members)
            {
                if (member.Age > oldestAge){
                    target = member;
                    oldestAge = member.Age;
                }
            }
            Console.WriteLine(target);
            Console.WriteLine("========================");
            Console.WriteLine("By full name:");
            foreach (var member in members)
            {
                Console.WriteLine(member.LastName+" "+member.FirstName);
            }
            Console.WriteLine("========================");
            var equal = new List<Member>();
            var greater = new List<Member>();
            var less = new List<Member>();
            foreach (var member in members)
            {
                var birthYear = member.DateOfBirth.Year;
                switch (birthYear)
                {
                    case int i when i > 2000:
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

            Console.WriteLine("===========================");
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
    }
}
