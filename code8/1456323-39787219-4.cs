    public static Element[] GetById<T, Tkey>(IQueryable<T> items,Tkey[] ids)
            {
                var type = typeof(T);
                ParameterExpression param = Expression.Parameter(type);
                var list = Expression.Constant(ids);
                //The names of the properties you need to get if all models have them and are named the same and are the same type this will work
                var idProp = Expression.Property(param, "Id");
                var descriptionProp = Expression.Property(param, "JobDescription");
    
                var contains = typeof(Enumerable).GetMethods().First(m => m.Name == "Contains" && m.GetParameters().Count() == 2).MakeGenericMethod(typeof(Tkey));
                var where = Expression.Lambda<Func<T, bool>>(Expression.Call(contains, list, idProp), param);
    
                return (items.
                    Where(where).
                    Select(Expression.Lambda<Func<T, Element>>(
                        Expression.MemberInit(
                        Expression.New(typeof(Element)),
                            Expression.Bind(typeof(Element).GetProperty("Id"), idProp),
                            Expression.Bind(typeof(Element).GetProperty("Description"), descriptionProp)), 
                            param))).ToArray();
            }
