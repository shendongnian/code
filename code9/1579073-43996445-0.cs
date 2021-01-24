    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                new Process(FILENAME);
            }
        }
        public enum FUNCTION_TYPES
        {
            STEP,
            PRINT
        }
        public enum PRINT_TYPES
        {
            PIC,
            GAP,
            TXT1,
            TXT2
        }
        public class Process
        {
            public static List<Process> processes = new List<Process>();
            public DateTime date { get; set; }
            public string description { get; set; }
            public List<Function> functions = null;
            public Process() 
            {
                functions = new List<Function>();
            }
            public Process(string filename)
            {
                Process newProcess = null;
                string cmdPattern = @"^(?'cmd'[^\s]+)";
                string newPattern = @"^(?'cmd'[^\s]+)\s+(?'date'[^\s]+)\s+(?'time'[^\s]+)\s+(?'description'.*)";
                Match match;
     
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                while((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    string command = Regex.Match(inputLine, cmdPattern).Groups["cmd"].Value;
                    switch (command)
                    {
                        case "NEW" :
                            newProcess = new Process();
                            processes.Add(newProcess);
                            match = Regex.Match(inputLine, newPattern);
                            date = DateTime.Parse(match.Groups["date"].Value + " " + match.Groups["time"].Value);
                            description = match.Groups["description"].Value;
                            break;
                        case "STP":
                            newProcess.functions.Add(new Step(inputLine));
                            break;
                        case "PRN":
                            newProcess.functions.Add(new Print(inputLine));
                            break;
                        case "END":
                            newProcess = null;
                            break;
                    }
                }
            }
        }
        public class Function
        {
            public FUNCTION_TYPES function { get; set; }
        }
        public class Step : Function
        {
            public int number { get; set; }
            public List<string> stepArray { get; set; }
            public Step(string stepStr)
            {
                function = FUNCTION_TYPES.STEP;
                stepArray = stepStr.Split(new string[] {" P "}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                string stepPattern = @"^(?'cmd'[^\s]+)\s+(?'number'[^\s]+)";
                Match match = Regex.Match(stepArray[0], stepPattern);
                number = int.Parse(match.Groups["number"].Value);
            }
        }
        public class Print : Function
        {
            public PRINT_TYPES printType { get; set; }
            public string imageFilename { get; set; }
            public int imageHeight { get; set; }
            public int imageWidth { get; set; }
            public string functionName { get; set; }
            public string[] functionArray { get; set; }
            public int[] gapArray { get; set; }
            public string txName { get; set; }
            public string[] txArray { get; set; }
            public Print(string printStr)
            {
                Match match;
                function = FUNCTION_TYPES.PRINT;
                string typePattern = @"^(?'cmd'[^\s]+)\s+(?'type'[^\s]+)";
                
                match = Regex.Match(printStr, typePattern);
                string typeStr = match.Groups["type"].Value;
                switch (typeStr)
                {
                    case "PIC" :
                        printType = PRINT_TYPES.PIC;
                        string picturePattern = @"^(?'cmd'[^\s]+)\s+(?'type'[^\s]+)\s+(?'filename'[^\s]+)\s+(?'height'[^\s]+)\s+(?'width'.*)";
                        match = Regex.Match(printStr, picturePattern);
                        imageFilename = match.Groups["filename"].Value;
                        imageHeight = int.Parse(match.Groups["height"].Value);
                        imageWidth = int.Parse(match.Groups["width"].Value);
                        break;
                    case "TX1":
                        printType = PRINT_TYPES.TXT1;
                        string tx1Pattern = @"^(?'cmd'[^\s]+)\s+(?'type'[^\s]+)\s+(?'txname'.+)(?'tx1'\d+)\s+(?'tx2'\d+)\s+(?'tx3'\d+)\s+(?'tx4'\d+)\s+(?'tx5'\w+)$";
                        match = Regex.Match(printStr, tx1Pattern, RegexOptions.RightToLeft);
                        txName = match.Groups["txname"].Value;
                        txArray = new string[] {
                            match.Groups["tx1"].Value,
                            match.Groups["tx2"].Value,
                            match.Groups["tx3"].Value,
                            match.Groups["tx4"].Value,
                            match.Groups["tx5"].Value
                        };
                        break;
                    case "TX2":
                        printType = PRINT_TYPES.TXT2;
                        string tx2Pattern = @"^(?'cmd'[^\s]+)\s+(?'type'[^\s]+)\s+(?'txname'.+)\s+Pass\s+(?'tx1'\d+)\s+(?'tx2'\d+)\s+(?'tx3'\d+)\s+(?'tx4'\d+)\s+(?'tx5'\w+)\s+(?'tx6'\d+)$";
                        match = Regex.Match(printStr, tx2Pattern, RegexOptions.RightToLeft);
                        txName = match.Groups["txname"].Value;
                        txArray = new string[] {
                            match.Groups["tx1"].Value,
                            match.Groups["tx2"].Value,
                            match.Groups["tx3"].Value,
                            match.Groups["tx4"].Value,
                            match.Groups["tx5"].Value,
                            match.Groups["tx6"].Value
                        };
                        
                        break;
                    case "GAP":
                        printType = PRINT_TYPES.GAP ;
                        string[] gapArrayStr = printStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        gapArray = gapArrayStr.Skip(2).Select(x => int.Parse(x)).ToArray();
                        break;
                }
            }
        }
    }
