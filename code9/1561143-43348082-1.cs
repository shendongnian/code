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
                //DateTime endTime = DateTime.Now;
                DateTime endTime = DateTime.Parse("2017-02-20 15:58:50");
                DateTime startTime = endTime.AddSeconds(-10);
                Session session = new Session(startTime, endTime);
                session.ReadFile(FILENAME);
            }
        }
        public class Session
        {
            public static List<Session> sessions = new List<Session>();
            public static DateTime startTime { get; set; }
            public static DateTime endTime { get; set; }
            public DateTime time { get; set; }
            public string name { get; set; }
            public List<string> properties { get; set; }
            public Session()
            {
            }
            public Session(DateTime startTime, DateTime endTime)
            {
                Session.startTime = startTime;
                Session.endTime = endTime;
            }
            public void ReadFile(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                Session newSession = null;
                Boolean skip = false;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (inputLine.StartsWith(".") && (skip == false))
                        {
                            newSession.properties.Add(inputLine);
                        }
                        if(!inputLine.StartsWith("."))
                        {
                            string[] array = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            DateTime time = DateTime.Parse(array[0] + ' ' + array[1]);
                            if ((time > startTime) && (time < endTime))
                            {
                                skip = false;
                                newSession = new Session();
                                newSession.properties = new List<string>();
                                Session.sessions.Add(newSession);
                                newSession.time = time;
                                newSession.name = array[5];
                            }
                            else
                            {
                                skip = true;
                            }
                        }
                    }
                }
            }
        }
    }
