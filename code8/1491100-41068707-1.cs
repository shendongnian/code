    static public Validation<T>
    {
        static public readony Fun<T, bool> Validate;
        static Validation
        {
            if (typeof(T) == typeof(string))
            {
                Validation<T>.Validate = new Func<T, bool>(value => 
                {
                    var _string = (string)(object)value;
                    //Do your test here
                    return true;
                });
            }
            else if (typeof(T) == typeof(int))
            {
                Validation<T>.Validate = new Func<T, bool>(value => 
                {
                    var _int32 = (int)(object)value;
                    //Do your test here
                    return true;
                });
            }
            //...
            else if (typeof(T).IsClass)
            {
                var validate = typeof(Validation).GetMethod("Validate");
                var parameter = Expression.Parameter(typeof(T));
                var properties = typeof(T).GetProperties();
                if (properties.length < 0)
                {
                    Validation<T>.Validate = new Func<T, bool>(value => true);
                }
                else
                {
                    var body = Expression.Constant(true);
                    foreach (var property in properties)
                    {
                        body = Expression.Condition(Expression.Call(validate.MakeGenericMethod(property.PropertyType), parameter), body, Expression.Constant(false));
                    }
                    Validation<T>.Validate = Expression.Lambda<Func<T, bool>>(body, parameter).Compile();
                }
            }
        }
    }
