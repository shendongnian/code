    public static class TempDataExt
        {
            public static void Put<T>(this ITempDataDictionary tempData,string key,T value)
            {
                tempData[key]=JsonConvert.SerializeObject(value);
            }
            public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
            {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
            }
        }
