    using Newtonsoft.Json;
    using System.Linq;
    
    public class Person {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("fullName")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName; 
            }
            set
            {
                if (value.Contains(" "))
                {
                    var split = value.Split(' ');
                    FirstName = split[0];
                    LastName = string.Join(" ", split.Skip(1));
                }
                else 
                {
                    FirstName = value;
                }
            }
        }
    
        [JsonIgnore]
        public string FirstName { get; set; }
    
        [JsonIgnore]
        public string LastName { get; set; }
    }
