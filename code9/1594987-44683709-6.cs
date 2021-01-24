    public static class LinqEitherExtension
    {
        public static IEnumerable<T> UntilException<T,TException>(
            this IEnumerable<Option<T,TException>> enumerable, 
            Action<TException> errorHandler
            )
        {
            return enumerable
                .TakeWhile(e =>
                               {
                                   e.MatchNone(errorHandler);
                                   return e.HasValue;
                               })
                .SelectMany(e => e.ToEnumerable());
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> {1, 2, 3, 4, 5};
            ThirdPartyFunction(numbers.Select(CheckNumbers).UntilException(Console.WriteLine));
            //returns: 
            //1     
            //2
            //3 is exceptional number.
        }
        public static Option<int,string> CheckNumbers(int number)
        {
            return number == 3
                ? Option.None<int, string>("3 is exceptional number.")
                : number.Some<int, string>();
        }
        //Cannot be accessed/altered
        public static void ThirdPartyFunction(IEnumerable<int> numbers)
        {
            foreach (var number in numbers) Console.WriteLine(number.ToString());
        }
    }
