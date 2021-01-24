    class Program
    {
        static void Main()
        {
            var fb =
                Enumerable.Range(0, 20)
                .Select(n => ((n % 3 == 0), (n % 5 == 0)))
                .Match(
                    ((true, true), () => "FizzBuzz"),
                    ((true, false), () => "Fizz"),
                    ((false, true), () => "Buzz")
                );
            Console.WriteLine(String.Join("\n", fb));
            Console.ReadKey();
        }
    }
    public static class Extensions
    {
        public static IEnumerable<TResult> Match<TInput, TResult>(
            this IEnumerable<TInput> e, 
            params ValueTuple<TInput, Func<TResult>>[] cases)
        {
            return
                from evalue in e
                join @case in cases on evalue equals @case.Item1
                select @case.Item2();
        }
    }
