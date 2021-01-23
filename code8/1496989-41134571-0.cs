    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum State
            {
                FIND_BLOCK,
                GET_ACDB_LINE,
                ACD_BLOCK
            }
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                State state = State.FIND_BLOCK;
                int lineRow = 0;
                Line newLine = new Line();
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_BLOCK :
                                switch (inputLine)
                                {
                                    case "AcDbBlockBegin" :
                                        state = State.ACD_BLOCK;
                                        break;
                                    case "AcDbLine":
                                        state = State.GET_ACDB_LINE;
                                        lineRow = 0;
                                        newLine = new Line();
                                        Line.lines.Add(newLine);
                                        break;
                                }
                                break;
     
                            case State.ACD_BLOCK :
                                if (inputLine == "AcDbBlockEnd")
                                {
                                    state = State.FIND_BLOCK;
                                }
                                break;
                            case State.GET_ACDB_LINE :
                                if (inputLine == "LINE")
                                {
                                    state = State.FIND_BLOCK;
                                }
                                else
                                {
                                    switch (++lineRow)
                                    {
                                        case 2:
                                            newLine.xLoc = double.Parse(inputLine);
                                            break;
                                        case 4:
                                            newLine.yLoc = double.Parse(inputLine);
                                            break;
                                        case 6:
                                            newLine.zLoc = double.Parse(inputLine);
                                            break;
                                        case 8:
                                            newLine.xVal = double.Parse(inputLine);
                                            break;
                                        case 10:
                                            newLine.yVal = double.Parse(inputLine);
                                            break;
                                        case 12:
                                            newLine.zVal = double.Parse(inputLine);
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            public class Line
            {
                public static List<Line> lines = new List<Line>();
                public double xLoc { get; set; }
                public double xVal { get; set; }
                public double yLoc { get; set; }
                public double yVal { get; set; }
                public double zLoc { get; set; }
                public double zVal { get; set; }
            }
        }
    }
