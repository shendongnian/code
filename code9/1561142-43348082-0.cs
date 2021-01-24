    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Session session = new Session();
                session.ReadFile(FILENAME);
            }
        }
        public class Session
        {
            public static List<Session> sessions = new List<Session>();
            public DateTime time { get; set;}
            public string name { get; set; }
            public List<string> properties { get; set; }
            public void ReadFile(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                Session newSession = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if(inputLine.StartsWith("."))
                        {
                            newSession.properties.Add(inputLine);
                        }
                        else
                        {
                            newSession = new Session();
                            newSession.properties = new List<string>();
                            Session.sessions.Add(newSession);
                            string[] array = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            newSession.time = DateTime.Parse(array[0] + ' ' + array[1]);
                            newSession.name = array[5];
                        }
                    }
                }
            }
        }
    }
