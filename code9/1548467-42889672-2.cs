    public static void enterData()
    {
        Console.WriteLine("Enter Student Number");
        studentNumber = Console.ReadLine();
        Console.WriteLine("Enter Name");
        studentName = Console.ReadLine();
        Console.WriteLine("Enter Age");
        age = Console.ReadLine();
        Console.WriteLine("Enter Phone Number");
        phoneNumber = Console.ReadLine();
    }
    public static void displayData()
    {
       Console.WriteLine("Student Number : {0}", studentNumber);
       Console.WriteLine("Student Name : {0}", studentName);
       Console.WriteLine("Student Age : {0}", age);
       Console.WriteLine("Student Phone Number :{0}", phoneNumber);
       Console.ReadKey(); 
    }
    public static void Main(String[] args)
    {
       enterData();
       displayData();
    }
