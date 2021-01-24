    public enum Gendertype { Male, Female };
        public class Person
        {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Gendertype Gender { get; set; }
        public int Age 
    	{
    		return DateTime.Now.Subtract(DateOfBirth).TotalDays / 365;
    	}
        public Person(string fn, string mn, string ln, DateTime dob, string n, Gendertype g)
        {
            FirstName = fn;
            MiddleName = mn;
            LastName = ln;
            DateOfBirth = dob;
            Nationality = n;
            Gender = g;
        }
    
    }
    class Program
    { 
    	static void Main()
    	{
    		Person person1 = new Person("Rafael" + "\n", "" + "\n", "Nadal" + "\n", new DateTime(1986,06, 03), "Spanish" + "\n", Gendertype.Male);
    		Console.WriteLine("Player 1: \n First name = {0} Middle name = {1 } Last name = {2} Date of birth = {3} \n Nationality = {4} Gender = {5}", person1.FirstName, person1.MiddleName, person1.LastName, person1.DateOfBirth, person1.Nationality, person1.Gender);
    		
    		Console.WriteLine(" Age:");
    		Console.WriteLine(person1.Age);
    		//Console.ReadLine(); this waits for your enter key
    
    		Person person2 = new Person("Rafael" + "\n", "" + "\n", "Nadal" + "\n", new DateTime(1988, 07, 04), "Spanish" + "\n", Gendertype.Male);
    		Console.WriteLine("Player 2: \n First name = {0} Middle name = {1 } Last name = {2} Date of birth = {3} \n Nationality = {4} Gender = {5}", person2.FirstName, person2.MiddleName, person2.LastName, person2.DateOfBirth, person2.Nationality, person2.Gender);
    		
    		Console.WriteLine(" Age:");
    		Console.WriteLine(person2.Age);
    		//Console.ReadLine(); this waits for your enter key
    
    
    		person2.FirstName = "Molly";
    		Console.WriteLine("Player 2: \n First name = {0} Middle name = {1 } Last name = {2} Date of birth = {3} \n Nationality = {4} Gender = {5}", person1.FirstName, person1.MiddleName, person1.LastName, person1.DateOfBirth, person1.Nationality, person1.Gender);
    		Console.WriteLine("person1 Name = {0} Age = {1}", person2.FirstName, person2.DateOfBirth.ToShortDateString());
    
    
    		Console.WriteLine("Press any key to exit.");
    		Console.ReadKey();
    	 }
    }
