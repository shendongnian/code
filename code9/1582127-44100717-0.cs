    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace TestConsoleApp
    {
        public class Class1
        {
    
            public class Result
            {
                public int Id { get; set; }
                public string AccountName { get; set; }
            }
    
            public class ModelWithArray
            {
                public int TotalRecords { get; set; }
                public List<Result> Result { get; set; }
                public int ResponseCode { get; set; }
                public string Status { get; set; }
                public string Error { get; set; }
            }
    
            public class Result2
            {
                public int Id { get; set; }
                public string AccountName { get; set; }
            }
    
            public class ModelWithoutArray
            {
                public Result2 Result { get; set; }
                public int ResponseCode { get; set; }
                public string Status { get; set; }
                public string Error { get; set; }
            }
    
            public static void Main(params string[] args)
            {
                //string json = "{\"TotalRecords\":2,\"Result\":[{\"Id\":24379,\"AccountName\":\"foo\"},{\"Id\":37209,\"AccountName\":\"bar\"}], \"ResponseCode\":0,\"Status\":\"OK\",\"Error\":\"None\"}";
                string json = "{\"Result\":{\"Id\":24379,\"AccountName\":\"foo\"},\"ResponseCode\":0,\"Status\":\"OK\",\"Error\":\"None\"}";
    
                if (checkIsArray(json))
                {
                    ModelWithArray data = JsonConver.DeserializeObject<ModelWithArray >(json);
                }else
                {
                    ModelWithoutArray data = JsonConver.DeserializeObject<ModelWithoutArray>(json);
                }
    
            }
    
            static bool checkIsArray(string json)
            {
    
                Dictionary<string, object> desData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    
                if (desData["Result"].GetType().Name.Contains("Array"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
    
            }
    
        }
    }
