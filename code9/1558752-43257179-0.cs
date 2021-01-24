    class Type1 { public string Name { get; set; } }
    class Data { public Expression<Func<Type1, string>> Ex { get; set; } }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Data { Ex = t => t.Name };
            var pi = d.GetType().GetProperties().Single();
            var ex = pi.GetValue(d) as LambdaExpression;
            Console.WriteLine(pi.GetValue(d).GetType());
            Console.WriteLine(ex);
            Console.WriteLine(ex.Parameters.Single());
        }
    }
