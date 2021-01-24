            public static MethodInfo GetLambdaExpressionMethod(Type type1, Type type2)
            {
                    return typeof(Expression).GetMethods().Where(x => x.Name == "Lambda").First()
                        .MakeGenericMethod(typeof(Func<,>).MakeGenericType(type1, type2));
            }
