    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace IEnumerable_IEnumerator_Recursive
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                Parser parser = new Parser(FILENAME);
                int level = 0;
                List<Part> root = new List<Part>();
                Part.Recurse(level, root);
            }
        }
        public class Parser
        {
            public Boolean EndOfData = false;
            public Parser(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        string[] fields = inputLine.Split(new char[] { ',' });
                        Part tempPart = new Part(fields[0], fields[1], fields[2], fields[3], fields[4]);
                        Part.allParts.Add(tempPart);
                    }
                }
                Part.MakeDictionary();
            }
        }
        public class PartEnumerator : IEnumerator<List<Part>>
        {
            List<Part> parts = null;
            
            public static SortedDictionary<string, int> maxCount = new SortedDictionary<string, int>() {
                {"A", 1},
                {"B", 2},
                {"C", 3},
                {"D", 1},
                {"E", 1},
                {"F", 1}
            };
            public int size = 0;
            List<int> enumerators = null;
            public PartEnumerator(string name, List<Part> parts)
            {
     
                this.parts = parts;
                size = maxCount[name];
                enumerators = new List<int>(new int[size]);
                Reset();
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public List<Part> Current
            {
                get
                {
                    try
                    {
                        List<Part> returnParts = new List<Part>();
                        foreach (int enumerator in enumerators)
                        {
                            returnParts.Add(parts[enumerator]);
                        }
                        return returnParts;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            public void Reset()
            {
                for (int count = 0; count < enumerators.Count; count++)
                {
                    enumerators[count] = count;
                }
            }
            
            public Boolean MoveNext()
            {
                Boolean moved = true;
                int listSize = parts.Count;
                int enumNumbers = enumerators.Count;
                //only use enumerators up to the size of list
                if (listSize < enumNumbers)
                {
                    enumNumbers = listSize;
                }
                Boolean ripple = true;
                int enumCounter = enumNumbers;
                if (enumCounter > 0)
                {
                    while ((ripple == true) && (--enumCounter >= 0))
                    {
                        ripple = false;
                        int maxCount = listSize - (enumNumbers - enumCounter);
                        if (enumerators[enumCounter] >= maxCount)
                        {
                            ripple = true;
                        }
                        else
                        {
                            for (int i = enumCounter; i < enumNumbers; i++)
                            {
                                if (i == enumCounter)
                                {
                                    enumerators[i] += 1;
                                }
                                else
                                {
                                    enumerators[i] = enumerators[i - 1] + 1;
                                }
                            }
                        }
                    }
                    if ((enumCounter <= 0) && (ripple == true))
                    {
                        moved = false;
                    }
                }
     
                return moved;
            }
            public void Dispose()
            {
            }
        }
        public class Part
        {
            public static List<Part> allParts = new List<Part>();
            public static Dictionary<string, PartEnumerator> partDict = new Dictionary<string, PartEnumerator>();
            public string idNum; //0 locations when being parsed
            public string name; //2
            public string group; //1
            public double tolerance; //4
            public long cost; //3
            public Part()
            {
            }
            public Part(string id, string nm, string grp, string tol, string cst)
            {
                idNum = id;
                name = nm;
                group = grp;
                tolerance = double.Parse(tol);
                cost = long.Parse(cst);
            }
            public static void MakeDictionary()
            {
                var listPartEnum = Part.allParts.GroupBy(x => x.name)
                    .Select(x => new { Key = x.Key, List = new PartEnumerator(x.Key, x.ToList()) });
                foreach (var partEnum in listPartEnum)
                {
                    partDict.Add(partEnum.Key, partEnum.List);
                }
            }
            public static string[] NAMES = { "A", "B", "C", "D", "E", "F" };
            public static void Recurse(int level, List<Part> results)
            {
                Boolean moved = true;
                if (level < PartEnumerator.maxCount.Keys.Count)
                {
                    //level is equivalent to names in the Part Enumerator dictionary A to F
                    string name = NAMES[level];
                    PartEnumerator enumerator = partDict[name];
                    enumerator.Reset();
                    while ((enumerator != null) && moved)
                    {
                        List<Part> allParts = new List<Part>(results);
                        allParts.AddRange((List<Part>)enumerator.Current);
                        int currentLevel = level + 1;
                        Recurse(currentLevel, allParts);
                        moved = enumerator.MoveNext();
                    }
                }
                else
                {
                    string message = string.Join(",", results.Select(x => string.Format("[id:{0},name:{1}]", x.name, x.idNum)).ToArray());
                    Console.WriteLine(message);
                }
            }
        }
    }
