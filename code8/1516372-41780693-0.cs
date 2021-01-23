    public static void CreateWorkbook(List<ExpandoObject> ItemList)
            {
                foreach(var item in ItemList)
                {
                    IDictionary<string, object> propertyValues = item;
    
                    foreach (var property in propertyValues.Keys)
                    {
                        Console.WriteLine(String.Format("{0} : {1}", property, propertyValues[property]));
                    } 
                }
            }
