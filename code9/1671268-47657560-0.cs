    object ob = MyObject;
    string datalevel = TheLevelIWant;
                            var data = ob.GetType().GetProperty("data").GetValue(ob);
    
                            if (data.GetType().IsGenericType)
                            {
                                foreach(object obj in (data as IEnumerable).Cast<object>().ToList())
                                {
                                    ob = obj.GetType().GetProperty(datalevel);
                                }
                            }
