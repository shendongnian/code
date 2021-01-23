    class Program {
          
       static void Main(string[] args) {
             var items = new List<string> { "1", "2", "3", "4" };
             B b = new B( items);
             foreach( var item in items ) {
                Console.WriteLine( item );
             }
             Console.Read();
       }
    }
    
    public class A {
       public A(List<string> data) {
          data.Add( "5" );
       }
    }
    
    public class B : A {
       public B(List<string> data) : base(data) {
          data.Add( "6" );
       }
    }
