    public class Program {
    	public static void Main() {
    		 Enumerable.Range(1, 10)
                  .When(i => i % 3 == 0).Then(i => Console.WriteLine("fizz"))
                  .When(i => i % 5 == 0).Then(i => Console.WriteLine("buzz"))
                  .Otherwise(i => Console.WriteLine(i))
                  .Run();
    	}
    }
