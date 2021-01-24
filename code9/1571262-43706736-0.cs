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
                new CenterLine(FILENAME);
            }
        }
        public class CenterLine
        {
            public static List<CenterLine> centerLines = new List<CenterLine>();
            public double centerLine { get; set; }
            public List<double> heights { get; set; }
            enum State
            {
                GET_CENTER_LINE,
                GET_HEIGHTS
            }
            public CenterLine() { }
            public CenterLine(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                State state = State.GET_CENTER_LINE;
                CenterLine newCenterLine = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.GET_CENTER_LINE :
                                newCenterLine = new CenterLine();
                                centerLines.Add(newCenterLine);
                                newCenterLine.centerLine = double.Parse(inputLine);
                                state = State.GET_HEIGHTS;
                                break;
                            case State.GET_HEIGHTS :
                                newCenterLine.heights = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => double.Parse(x)).ToList();
                                state = State.GET_CENTER_LINE;
                                break;
                        }
                    }
                }
            }
        }
    }
