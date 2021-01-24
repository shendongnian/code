    internal class Program {
    
       private static void Main(string[] args) {
    
          var p1 = new Person { Name = "George" };
          ChangeName( p1 );
    
          // This will have "George"
          var name = p1.Name;
    
          ChangeName2( p1 );
    
          // This will have "Jerry"
          var name2 = p1.Name;
    
          var p2 = new Person { Name = "Kramer" };
          ChangeName( ref p2 );
          var name3 = p2.Name;
    
          Console.Read();
       }
    
       public static void ChangeName(Person person) {
          // This is a whole new person
          var p = new Person() { Name = "Smith" };
          person = p;
       }
    
       public static void ChangeName2(Person person) {
          person.Name = "Jerry";
       }
    
       // This takes the reference and assigns a new person to the reference
       public static void ChangeName(ref Person person) {
          var p = new Person() { Name = "Smith" };
          person = p;
       }
    }
