    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                LineItem item = new LineItem
                {
                    OrderId = 10
                };
    
                 
                string json = JsonConvert.SerializeObject(item, Formatting.Indented);
                var t = JsonConvert.DeserializeObject<LineItem>(json);
            }
            public class LineItem
            {
                [JsonIgnore]
                [Required]
                public int OrderId { get; set; }
            }
        }
    }
