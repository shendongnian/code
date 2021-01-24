    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic; 
    using Newtonsoft.Json.Linq;
    namespace com.example.Json
    {
        public class Action
        {
            public string Type { get; set; }
        }
        public class Action1 : Action
        {
            public string Data { get; set; }
        }
        
        public class Action2 : Action
        {
            public string SomeProperty { get; set; }
        }
        public class Program
        {
        
            public const string ACTION1 = @"{
            ""Type"" : ""com.example.Json.Action1"",
                ""Data"" : ""41°24'12.2 N 2°10'26.5""
            }";
        
            public const string ACTION2 = @"{
            ""Type"" : ""com.example.Json.Action2"",
                ""SomeProperty"" : ""arbitrary-value""
            }";
            
            public const string ACTIONS =  
                "[" + 
                ACTION1 +
                "," + 
                ACTION2 +
                "]" ;
            public static void Main()
            {
                
                var actions = new List<Action>();
                
                JArray jArray = JArray.Parse(ACTIONS);
                foreach(var item in jArray)
                {
                    var json = JsonConvert.SerializeObject(item);
                    var baseAction = JsonConvert.DeserializeObject<Action>(json);
                    var type = Type.GetType(baseAction.Type);
                    var action = (Action) JsonConvert.DeserializeObject(json, type);
                    actions.Add(action);
                }
                // now that we have converted all array items into specific derived action objects
                // we can start processing them anyway we want
                // keep in mind that you have to check the runtime type in order to find out what
                // specific kind of action we have
                // eg.
                foreach(var action in actions)
                {
                    switch(action.Type)
                    {
                        case "com.example.Json.Action1":
                            // do something
                            Console.WriteLine("found com.example.Json.Action1");
                            Console.WriteLine((action as Action1).Data);
                            break;
                        case "com.example.Json.Action2":
                            // do something
                            Console.WriteLine("found com.example.Json.Action2");
                            Console.WriteLine((action as Action2).SomeProperty);
                            break;
                        default:
                            // do something
                            Console.WriteLine("found something else");
                            break;
                    }
                }
            }
            
        }
    }
