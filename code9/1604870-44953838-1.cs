    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication64
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static List<string> sections = null;
            public enum State
            {
                NONE = -1,
                CHANGESET = 0,
                USER,
                DATE,
                COMMENT,
                ITEMS,
                WORK_ITEMS,
                CHECK_IN_NOTES
            }
            
            static void Main(string[] args)
            {
                sections = new List<string>() { "Changeset", "User", "Date", "Comment", "Items", "Work Items", "Check-In Notes" }; 
                string pattern = "^(?'section'[^:]+)";
                string inputLine = "";
                StreamReader reader = new StreamReader(FILENAME);
                State state = State.NONE; 
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    Match match = Regex.Match(inputLine, pattern);
                    if (match.Success)
                    {
                        int index = sections.IndexOf(match.Groups["section"].Value);
                        if(index >= 0) state = (State)index;
                    }
                    switch(state)
                    {
                        case State.COMMENT :
                            Console.WriteLine(inputLine);
                            break;
                        case State.ITEMS :
                            Console.WriteLine(inputLine);
                            break;
                    }
                }
                Console.ReadLine();
            }
        }
    }
