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
        class Class1
        {
            public SqlConnection con = new SqlConnection(@"server=SERVE;database=DATABASE;uid=XX;password=XXXX;MultipleActiveResultSets=True");
            public SqlCommand cmd;
            public SqlDataReader dr1;
    
            public string json { get; set; }
            public JToken[] response { get; set; }
    
    
            static void Main()
            {
                Class1 obj = new Class1();
                obj.DoSomething();
            }
    
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
    
            public void DoSomething()
            {
                var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http:URL");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
    
                using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"Username\":\"DEV\"}";
    
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
    
                        this.CONNECTION();
                        string insert = "INSERT INTO [DATABASE].[dbo].[TEST6] (datet) VALUES ('" + datetime + "');";
                        this.executeNonQuery(insert);
                        
                    }
                }
            }
        }
    }
