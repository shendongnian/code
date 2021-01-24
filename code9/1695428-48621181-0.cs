    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Rextester
    {
        public class Program
        {
            private static Dictionary<string, string> dataAtIndex(Dictionary<string, List<string>> iArgs, Dictionary<string, int> iArgIndex)
            {
                Dictionary<string, string> oConditionKeys = new Dictionary<string, string>();
    
                foreach (var vArgName in iArgs.Keys)
                {
                    int index = iArgIndex[vArgName];
                    string argValue = iArgs[vArgName][index];
                    oConditionKeys.Add(vArgName, argValue);
                }
    
                return oConditionKeys;
            }
    
            private static void generateArgIndexList(Dictionary<string, List<string>> iArgs, Dictionary<string, int> iArgIndex, ref List<Dictionary<string, int>> oListArgIndices)
            {
                if(iArgs.Count > 0)
                {
                    string firstArgName = iArgs.First().Key;
    
                    Dictionary<string, List<string>> newArgs = new Dictionary<string, List<string>>(iArgs);
                    Dictionary<string, int> tmpArgInd = iArgIndex; // Use copy...
                    while (tmpArgInd[firstArgName] < iArgs[firstArgName].Count)
                    {
                        string lastArgName = newArgs.Last().Key;
                        if (tmpArgInd[lastArgName] < iArgs[lastArgName].Count)
                        {
                            oListArgIndices.Add(new Dictionary<string, int>(tmpArgInd));
                            ++tmpArgInd[lastArgName];
                        }
                        else
                        {
                            tmpArgInd[lastArgName] = 0;
                            newArgs.Remove(lastArgName);
                            lastArgName = newArgs.Last().Key;
                            if (tmpArgInd[lastArgName] < iArgs[lastArgName].Count)
                            {
                                ++tmpArgInd[lastArgName];
                                if (tmpArgInd[lastArgName] < iArgs[lastArgName].Count)
                                    generateArgIndexList(iArgs, tmpArgInd, ref oListArgIndices);
                            }
                        }
                    }
                }
            }
    
            private static void testFunc(Dictionary<string, List<string>> iArgs, ref List<Dictionary<string, string>> oListConditionKeys)
            {
                Dictionary<string, int> argIndex = new Dictionary<string, int>();
                foreach (var vArgName in iArgs.Keys)
                {
                    argIndex.Add(vArgName, 0);
                }
    
                List<Dictionary<string, int>> listArgIndices = new List<Dictionary<string, int>>();
                generateArgIndexList(iArgs, argIndex, ref listArgIndices);
                foreach(var vArgIndex in listArgIndices)
                {
                    oListConditionKeys.Add(dataAtIndex(iArgs, vArgIndex));
                }
            }
    
    
            public static void Main(string[] mainargs)
            {
                Dictionary<string, List<string>> args = new Dictionary<string, List<string>>();
    
                List<string> listArgData1 = new List<string>();
                listArgData1.Add("1=>Arg0");
                listArgData1.Add("1=>Arg1");
                listArgData1.Add("1=>Arg2");
    
                List<string> listArgData2 = new List<string>();
                listArgData2.Add("2=>Arg0");
                listArgData2.Add("2=>Arg1");
    
                List<string> listArgData3 = new List<string>();
                listArgData3.Add("3=>Arg0");
                listArgData3.Add("3=>Arg1");
                listArgData3.Add("3=>Arg2");
                listArgData3.Add("3=>Arg3");
    
                args.Add("Param1", listArgData1);
                args.Add("Param2", listArgData2);
                args.Add("Param3", listArgData3);
    
                Console.WriteLine("Input Data : ");
                foreach(var vKey in args.Keys) {
                    Console.Write(vKey + " : ");
                    foreach(var vData in args[vKey]) {
                        Console.Write(vData + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
    
                List<Dictionary<string, string>> listSelectKeys = new List<Dictionary<string, string>>();
                testFunc(args, ref listSelectKeys);
    
                int count = 0;
                Console.WriteLine("Output Data : ");
                foreach(var vElem in listSelectKeys) {
                    Console.Write(count++ + " : ");
                    foreach(var vKey in vElem.Keys) {
                        Console.Write("(" + vKey + ", " + vElem[vKey] + ") ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
