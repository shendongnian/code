    using StackExchange.Redis;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string folderPath = @"C:\RedisCache\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + @"\";
                    Directory.CreateDirectory(folderPath);
                    IDictionary<string, string> dicts = GetDataFromDataBase();
                    
                    foreach (var dic in dicts)
                    {
                        using (TextWriter tw = new StreamWriter(folderPath + dic.Key + ".txt"))
                        {
                            tw.WriteLine(dic.Value);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
    
            public static ConnectionMultiplexer Connection
            {
                get
                {
                    return ConnectionMultiplexer.Connect("serverName: port");
                }
            }
    
            public static Dictionary<string, string> GetDataFromDataBase(string sPattern = "*")
            {
                int dbName = 2; //or 0, 1, 2
                Dictionary<string, string> dicKeyValue = new Dictionary<string, string>();
                var keys = Connection.GetServer("serverName: port").Keys(dbName, pattern: sPattern);
                string[] keysArr = keys.Select(key => (string)key).ToArray();
    
                foreach (var key in keysArr)
                {
                    dicKeyValue.Add(key, GetFromDB(dbName, key));
                }
    
                return dicKeyValue;
            }
    
            public static string GetFromDB(int dbName, string key)
            {
                var db = Connection.GetDatabase(dbName);
                return db.StringGet(key);
            }
        }
    }
