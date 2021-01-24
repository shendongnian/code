    using System;
    using System.Web.Script.Serialization;
    using System.IO;
    
    namespace DesrializeJson1ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var jsonFile = "test2.json";
                string jsonstring = File.ReadAllText(jsonFile);
                var serializer = new JavaScriptSerializer();
                MyClass aClass = serializer.Deserialize<MyClass>(jsonstring);
                Console.WriteLine("--------------------------");
                Console.WriteLine("message  :" + aClass.message);
                Console.WriteLine("message_state :" + aClass.message_state);
                Console.WriteLine("warning_message :" + aClass.warning_message);
                Console.WriteLine("message_html  :" + aClass.message_html);
                Console.WriteLine("--------------------------");
                Console.Read();
            }
        }
        public class MyClass
        {
            public int post_id { get; set; }
            public int thread_id { get; set; }
            public int user_id { get; set; }
            public string username { get; set; }
            public int post_date { get; set; }
            public string message { get; set; }
            public int ip_id { get; set; }
            public string message_state { get; set; }
            public int attach_count { get; set; }
            public int position { get; set; }
            public int likes { get; set; }
            public string like_users { get; set; }
            public int warning_id { get; set; }
            public string warning_message { get; set; }
            public int last_edit_date { get; set; }
            public int last_edit_user_id { get; set; }
            public int edit_count { get; set; }
            public int node_id { get; set; }
            public string title { get; set; }
            public string tags { get; set; }
            public string node_title { get; set; }
            public object node_name { get; set; }
            public string message_html { get; set; }
            public string absolute_url { get; set; }
        }
    }
