    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string blah = "{'Result': { 'StudentInfo': { 'ID': 20, 'Name': 'Bob', 'IgnoreThis': [{'ID': 123,'Something':'abc'}]}, 'Courses': [{'ID': 1,'CourseName':'Math'},{'ID': 2,'CourseName':'History'}]}}";
    
                dynamic json = JsonConvert.DeserializeObject(blah);
                var dynamicJson = json.Result.Courses; // included to show how dynamic could be accessed instead
    
                JObject arr = json;
    
                foreach (var course in arr["Result"]["Courses"].Where(x => x["ID"].Value<int>() == 2))
                {
                    course["CourseName"] = "Gym";
                }
    
                var newResult = json.ToString();
            }
        }
    }
