        class Program
        {
         static void Main(string[] args)
         {
          Console.WriteLine("This is a text adventure! <press space to continue>");
          Console.ReadKey();
          string a ;
          do
           {
           Console.WriteLine("A monster aproaches what do you do? <Attack,Flee>");
           a = Console.ReadLine();
         } while(a != "Attack" && a != "Flee"); 
        
        }
        }
