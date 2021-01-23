            static void Main(string[] args)
            {
    
    
                test2 foo = new test2();
                test t = new test();
                t.age = "10";
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("data", t);
                dict.Add("name", "Test Name");
    
                var fieldValues = foo.GetType()
                            .GetFields()
                            .ToList();
                foreach (var value in dict)
                {
                    foreach (var field in fieldValues)
                    {
    
    
                        if (value.Key == field.Name)
                        {
                            bool obj = field.FieldType == typeof(test);
                            if (obj)
                            {
                                // field.SetValue(foo.data, t);
                                var prop = foo.GetType().GetField("data", System.Reflection.BindingFlags.Public
                                | System.Reflection.BindingFlags.Instance);
                                prop.SetValue(foo, t);
                                break;
                            }
                            else
                            {
                                var prop = foo.GetType().GetField(value.Key, System.Reflection.BindingFlags.Public
                                | System.Reflection.BindingFlags.Instance);
                                prop.SetValue(foo, value.Value);
                                break;
                            }
                        }
                    }
    
                }
    
    
            }
