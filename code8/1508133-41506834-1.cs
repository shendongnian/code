    public class Program
    {
        static void Main(string[] args)
        {
          Person p = null;
            try
            {
               p = new Person("kim");
               
               if(p.Name == "kim")
               {
                   throw new PersonException();
               }
            }
            catch (PersonException z)
            {
                Console.WriteLine(z.Message);
            }
        }
    }
