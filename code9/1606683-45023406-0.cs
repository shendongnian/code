    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Job.Load(FILENAME);
            }
        }
        public class Job
        {
            public static List<Job> jobs = new List<Job>();
            public string name { get;set;}
            public string job_type { get;set;}
            public int date_conditions { get; set;}
            public DayOfWeek[] days_of_week { get; set; }
            public string condition { get; set; }
            public int alarm_if_fail { get; set; }
            public int job_load { get; set; }
            public int priority { get; set;}
            public static void Load(string filename)
            {
                Job newJob = null;
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if ((inputLine.Length > 0) && (!inputLine.StartsWith("/*")))
                    {
                        List<KeyValuePair<string, string>> groups = GetGroups(inputLine);
                        foreach (KeyValuePair<string, string> group in groups)
                        {
                            switch (group.Key)
                            {
                                case "insert_job" :
                                    newJob = new Job();
                                    Job.jobs.Add(newJob);
                                    newJob.name = group.Value;
                                    break;
                                case "job_type":
                                    newJob.job_type = group.Value;
                                    break;
                                case "date_conditions":
                                    newJob.date_conditions = int.Parse(group.Value);
                                    break;
                                case "days_of_week":
                                    List<string> d_of_w = new List<string>() { "su", "mo", "tu", "we", "th", "fr", "sa" };
                                    newJob.days_of_week = group.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => (DayOfWeek)d_of_w.IndexOf(x)).ToArray();
                                    break;
                                case "condition":
                                    newJob.condition = group.Value;
                                    break;
                                case "alarm_if_fail":
                                    newJob.alarm_if_fail = int.Parse(group.Value);
                                    break;
                                case "job_load":
                                    newJob.job_load = int.Parse(group.Value);
                                    break;
                                case "priority":
                                    newJob.priority = int.Parse(group.Value);
                                    break;
                            }
                        }
                    }
                }
                reader.Close();
            }
            public static List<KeyValuePair<string, string>> GetGroups(string input)
            {
                List<KeyValuePair<string, string>> groups = new List<KeyValuePair<string, string>>();
                string inputLine = input;
                while(inputLine.Length > 0)
                {
                    int lastColon = inputLine.LastIndexOf(":");
                    string value = inputLine.Substring(lastColon + 1).Trim();
                    int lastWordStart = inputLine.Substring(0, lastColon - 1).LastIndexOf(" ") + 1;
                    string name = inputLine.Substring(lastWordStart, lastColon - lastWordStart);
                    groups.Insert(0, new KeyValuePair<string,string>(name,value));
                    inputLine = inputLine.Substring(0, lastWordStart).Trim();
                }
                return groups;
            }
          
        }
    }
