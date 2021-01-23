    using System;
    using System.Collections.Generic;
    using SimpleInjector;
    class Query { }
    class Result { }
    class GetData : Query { }
    class Data : Result { }
    class IHandler<TIn, TOut> { }
    class IQueryHandler<TQuery, TResult> : IHandler<TQuery, IEnumerable<TResult>> { }
    class DefaultQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> { }
    
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.RegisterConditional(
                typeof(IHandler<,>),
                typeof(DefaultQueryHandler<,>),
                c => !c.Handled);
            var handler = container.GetInstance<IHandler<GetData, IEnumerable<Data>>>();
            Console.WriteLine(handler.GetType().FullName);
            Console.ReadLine();
        }
    }
