        public static void ProcessJObject(JProperty obj)
        {
            string name = obj.Name;
            string value = "";
            if (obj.Value.Type == JTokenType.Array)
            {
                Console.WriteLine("Array: " + name);
                ProcessJArray((JArray)obj.Value);
            }
            else
            {
                value = (string)obj.Value;
                Console.WriteLine(name + "-- " + value);
            }
            
            
        }
        public static void ProcessJArray(JArray arr)
        {
            foreach (JObject o in arr.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    ProcessJObject(p);
                }
            }
        }
        static void Main(string[] args)
        {
            string sJSON = @"   [{""dateNumeric"":1216000000,""hourOfDay"":0,""customerNumber"":12,""storedepartment"":[{""department"":333,""descriptionOfDepartment"":""Department A""},{""department"":111,""descriptionOfDepartment"":""Department B""}]},{""dateNumeric"":1216000000,""hourOfDay"":3,""customerNumber"":3,""storedepartment"":[{""department"":999,""descriptionOfDepartment"":""Department X""},{""department"":888,""descriptionOfDepartment"":""Department Y""}]}]";
            JArray a = JArray.Parse(sJSON);
            ProcessJArray(a);
            Console.Read();
        }
