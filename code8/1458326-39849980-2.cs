    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace SO_39849909
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, object> myDict = new Dictionary<string, object>();
                myDict.Add("task", new Dictionary<string, object>());
                Dictionary<string, object> innerDict = (myDict["task"] as Dictionary<string, object>);
                innerDict.Add("taskState", "Running");
                innerDict.Add("taskStatus", "Ok");
                innerDict.Add("completedSteps", 1);
                innerDict.Add("taskProgress", new List<dynamic>());
                List<dynamic> taskProgress = (innerDict["taskProgress"] as List<dynamic>);
                taskProgress.Add(new { message = "test message", timeStamp = DateTime.Now });
                string json = JsonConvert.SerializeObject(myDict, Formatting.Indented);
                Console.WriteLine(json);
                Console.ReadLine();
            }
        }
    }
