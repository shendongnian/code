    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.FromResult(1);
    
            var constantExpression = Expression.Constant(task, task.GetType());
            var propertyExpression = Expression.Property(constantExpression, "Result");
            var conversion = Expression.Convert(propertyExpression, typeof(object));
            var lambda = Expression.Lambda<Func<object>>(conversion);
            Func<object> compiled = lambda.Compile();
            
            Console.WriteLine(compiled());    
        }
    }
