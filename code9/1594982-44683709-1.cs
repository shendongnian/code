    public static class LinqEitherExtension
    {
        public static IEnumerable<TResult> SelectUntilException<T,TResult,TException>(
            this IEnumerable<T> enumerable, 
            Func<T,Option<TResult,TException>> selector,
            Action<TException> errorHandler
            )
        {
            return enumerable
                .Select(selector)
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
            ThirdPartyFunction(numbers.SelectUntilException(CheckNumbers, Console.WriteLine));
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
