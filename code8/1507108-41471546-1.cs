    static void Main(string[] args)
        {
            string[] studentInformation = getstudentinformation();
            string firstname = studentinformation[0];
        }
        static string[] getstudentinformation()
        {
            Console.WriteLine("enter the student's first name: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("enter the student's last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("enter student's gender");
            string gender = Console.ReadLine();
            string[] studentinformation = { firstname, lastname, gender };
            return studentinformation;
        }
