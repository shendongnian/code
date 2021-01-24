            var type = (new List<int>()).GetType();
            if (type.GetInterface("IList") != null && type.IsGenericType
                    && type.GenericTypeArguments.Length == 1
                    && type.GenericTypeArguments[0] == typeof(int))
                        Console.WriteLine(true); //Outputs True
