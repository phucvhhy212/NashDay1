namespace Day1
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string FullName => LastName + " " + FirstName;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public bool IsGraduated { get; set; }

        public override string ToString()
        {
            return
                $"First name: {FirstName}, Last Name: {LastName}, Gender: {Gender}, DateOfBirth: {DateOfBirth}, PhoneNumber: {PhoneNumber}, BirthPlace: {BirthPlace}, Age: {Age}, IsGraduated: {IsGraduated}";
        }
    }
}
