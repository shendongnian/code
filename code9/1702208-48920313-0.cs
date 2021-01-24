    public class Iterating
    {    
        public void Test2(List<String> employees)
        {
            //This is where I am trying to iterate//
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
     
    public class Testing
    {
        public List<String> Test1()
        {
            List<String> employees = new List<String>();//this should be outside the while loop
            while (true)
            {    
                Regex regex = new Regex(@"((.{5})-\d{2,5}-\d{2,5})|(@.*.com)");
                Console.WriteLine("Please enter an e-mail");
                string input = Console.ReadLine();
    
                if(string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.WriteLine("You have quit the program");
                    break;
                }
                else if (match.Success)
                {
                    Console.WriteLine(match.Value);//where is the match var
                    employees.Add(match.Value);//where is the match var
                }
            }
            return employees;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Testing T1 = new Testing();
            var employees = T1.Test1();
            Iterating I1 = new Iterating();
            I1.Test2(employees);
        }
    }
