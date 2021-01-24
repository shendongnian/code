    using System;
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;
    namespace ConsoleApp4
    {
        public class Compiler
        {
            public static Func<CustomDynamic, TResult> Compile<TResult>(string body)
            {
                ParameterExpression prm = Expression.Parameter(typeof(CustomDynamic), typeof(CustomDynamic).Name);
                LambdaExpression exp = DynamicExpressionParser.ParseLambda(new[] { prm }, typeof(TResult), body);
                return (Func<CustomDynamic, TResult>)exp.Compile();
            }
        }
    }
