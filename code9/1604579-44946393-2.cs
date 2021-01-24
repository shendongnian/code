    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Data.SqlClient;
    using System.Configuration;
    
    namespace DeserializeJson2ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Get the Json string
                string jsonstring = File.ReadAllText(@"D:\My Apps\Console Applications\DeserializeJson2ConsoleApp\DeserializeJson2ConsoleApp\test1.json");
                //Deserialize the json string to the object/class format
                var serializer = new JavaScriptSerializer();
                AllItems allItemsObj = serializer.Deserialize<AllItems>(jsonstring);
                //Save the deserilized object/class to database
                //Get your connection string defined inside the Web.config(for web application) / App.config(for console/windows/wpf/classlibrary application) file
                string myConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                //Create your Sql Connection here
                using (SqlConnection con = new SqlConnection(myConnectionString))
                {
                    //Open the sql connection
                    con.Open();
                    //Loop each items and save to database
                    foreach (var item in allItemsObj.Items)
                    {
                        //Save/Insert to database
                        if(SaveToDatabase(con, item))
                        {
                            Console.WriteLine("Success : " + item.Description + " Saved into database");
                        }
                        else
                        {
                            Console.WriteLine("Error : " + item.Description + " unable to Saved into database");
                        }
                    }
                }
                Console.Read();
            }
    
            /// <summary>
            /// Insert to database
            /// </summary>
            /// <param name="con"></param>
            /// <param name="aItemObj"></param>
            /// <returns></returns>
            static bool SaveToDatabase(SqlConnection con,Item aItemObj)
            {
                try
                {
                    string insertQuery = @"Insert into AllItemsTable(LocalTimestamp,Id,Description,Processed,Position1,Position2) Values(@LocalTimestamp,@Id,@Description,@Processed,@Position1,@Position2)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@LocalTimestamp",aItemObj.LocalTimestamp));
                        cmd.Parameters.Add(new SqlParameter("@Id", aItemObj.Id));
                        cmd.Parameters.Add(new SqlParameter("@Description", aItemObj.Description));
                        cmd.Parameters.Add(new SqlParameter("@Processed", aItemObj.Processed));
                        for(int index=0;index<aItemObj.Position.Count;index++)
                        {
                            if(index==0)
                                cmd.Parameters.Add(new SqlParameter("@Position1", aItemObj.Position[index].ToString()));
                            else
                                cmd.Parameters.Add(new SqlParameter("@Position2", aItemObj.Position[index].ToString()));
                        }
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception objEx)
                {
                    return false;
                }
            }
        }
    
        public class Item
        {
            public string LocalTimestamp { get; set; }
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Processed { get; set; }
            public List<double> Position { get; set; }
        }
    
        public class AllItems
        {
            public List<Item> Items { get; set; }
            public bool HasMoreResults { get; set; }
        }
    }
