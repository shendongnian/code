    internal class Program {
    
       private static void Main(string[] args) {
    
          var p1 = new Person { Name = "George" };
          ChangeName( p1 );
    
          // This will have "George" because the method never operated
          // on the person passed to it. 
          var name = p1.Name;
    
          // Now we call this method which will change the name of the person
          // we are passing to it.
          ChangeName2( p1 );
    
          // Therefore, now it will have "Jerry"
          var name2 = p1.Name;
    
          var p2 = new Person { Name = "Kramer" };
          // Now we do the exact same thing we did when we passed by value,
          // but now we pass by ref.
          ChangeName( ref p2 );
          
          // This will have "Smith" 
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
