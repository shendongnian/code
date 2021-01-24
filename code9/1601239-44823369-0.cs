    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace JsonIgnore
    {
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new myClass() { Age = 18, Name = "Max" };
                var selializedObj = JsonConvert.SerializeObject(obj);
                Console.WriteLine(selializedObj.ToString());
                Console.ReadLine();
            }
        }
    
        [DataContract]
        public class myClass
        {
            [JsonIgnore]
            [DataMember]
            public int Age { get; set; }
            [DataMember]
            public string Name { get; set; }
        }
    }
