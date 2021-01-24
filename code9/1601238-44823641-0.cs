            public class JsonArray
            {
                public string param1 { get; set; }
                public string param2 { get; set; }
                public string param3 { get; set; }
                public string param4 { get; set; }
            }
    
            public class MyClass
            {
                public List<JsonArray> json_array { get; set; }
                public bool status { get; set; }
            }
    
    
            public static void Main()
            {
                // init
                var myClassObj = new MyClass();
    
                myClassObj.json_array = new List<JsonArray>();
                myClassObj.json_array.Add(new JsonArray { param1 = null, param2 = null, param3 = null, param4 = null });
                myClassObj.json_array.Add(new JsonArray { param1 = null, param2 = null, param3 = null, param4 = null });
                myClassObj.status = true;
    
                // to JSON
                var json = FilterAndGetJsonFromObject(myClassObj);
            }
    
            public static string FilterAndGetJsonFromObject(MyClass myClassObj)
            {
                // filter null params
                foreach (var jsonArray in myClassObj.json_array.ToList())
                {
                    if (jsonArray.param1 == null && jsonArray.param2 == null && jsonArray.param3 == null && jsonArray.param4 == null)
                    {
                        myClassObj.json_array.Remove(jsonArray);
                    }
                }
    
                // serialize to json
                return new JavaScriptSerializer().Serialize(myClassObj);
            }
