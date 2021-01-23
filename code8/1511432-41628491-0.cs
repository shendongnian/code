    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System.Data.SqlClient;
    using System.Data;
    using HttpWebRequestResponse;
    namespace JSONARECHESTRA
    {
    class Class1{
        
        static void Main()
        {
            Class1 obj = new Class1();
            obj.Start();
        }
        private void Start()
        {
            Console.WriteLine("It is Start() method");
        }
       
        
            public SqlConnection con = new SqlConnection(@"server=TNGSRV;database=astha;uid=sa;password=Admin@1234;MultipleActiveResultSets=True");
            public SqlCommand cmd;
            public SqlDataReader dr1 ;
            public void CONNECTION()
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            public void executeNonQuery(string query)
            {
                CONNECTION();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
           public class user
    
           {
               private static JToken[] response;
               static void start()
        {
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://182.18.161.47:99/vts.svc/geo");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"Username\":\"wave\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(result);
                response = jObject["Rdata"][0].ToArray();
                JArray array = (JArray)jObject["Rdata"];
                for (int i = 0; i <= 3; i++)
                {
                    int Alert_Type = Convert.ToInt32((string)array[i]["Alert_Type"]);
                    DateTime datetime = Convert.ToDateTime((string)array[i]["Date_time"]);
                    string Location = Convert.ToString((string)array[i]["Location"]);
                    string Vehicle = Convert.ToString((string)array[i]["Vehicle"]);
                    Console.WriteLine(Vehicle);
                    Console.ReadKey();
                    Class1 cs = new Class1();
                    cs.CONNECTION();
                    string insert = "INSERT INTO [astha].[dbo].[TEST6] (datet) VALUES ('" + datetime + "');";
                    cs.executeNonQuery(insert);
                   //return Page_Load;
                }
            }
        }
           
        public string json { get; set; }
       
                
       }
    }
        
