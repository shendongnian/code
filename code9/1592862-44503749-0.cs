    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication62
    {
        enum State
        {
            FIND_KEY,
            GET_STATUS,
            GET_KEY_STRINGS
        }
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                new Key(FILENAME);
            }
        }
        public class Key
        {
            public static List<Key> keys = new List<Key>();
            public int id { get; set; }
            public Boolean status { get; set; }
            List<string> keysStrs = new List<string>();
            public Key() { }
            public Key(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                State state = State.FIND_KEY;
                Key newKey = null;
                while((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if(inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_KEY :
                                if(inputLine.StartsWith("KEY_ID:"))
                                {
                                    newKey = new Key();
                                    keys.Add(newKey);
                                    int id = int.Parse(inputLine.Substring(inputLine.LastIndexOf(" ")));
                                    newKey.id = id;
                                    state = State.GET_STATUS;
                                }
                                break;
                            case State.GET_STATUS:
                                if (inputLine.StartsWith("STATUS:"))
                                {
                                    string status = inputLine.Substring(inputLine.LastIndexOf(" ")).Trim();
                                    newKey.status = status == "VALID" ? true : false;
                                    state = State.GET_KEY_STRINGS;
                                }                            
                                break;
                            case State.GET_KEY_STRINGS:
                                if (!inputLine.StartsWith("-"))
                                {
                                    newKey.keysStrs.Add(inputLine.Trim());
                                }
                                else
                                {
                                    if (inputLine.Contains("END PUBLIC KEY"))
                                    {
                                        state = State.FIND_KEY;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
