    class Program
    {
        static void Main(string[] args)
        {
            string[] students=new string[] {
                "Miguel", "Maddie", "John", "Isabella", "Raul" };
            int[] grades=new int[] { 
                90, 85, 70, 92, 87 }; // arrays, grades for each students...
            Console.WriteLine("Please enter your name: "); // Asking the user to type his/her name
            string studentName=Console.ReadLine(); //
            for (int i=0; i<students.Length; i++)
            {
                if (students[i].Equals(studentName))
                {
                    Console.WriteLine(studentName+" your score was "+grades[i].ToString());
                }
            }
        }
    }
