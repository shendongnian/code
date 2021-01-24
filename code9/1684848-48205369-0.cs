    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApp1
    {
        class Program
        {
            const int singleDataLength = 12;    // from 0x02 to 0x03
            const int weightDataLength = 7;     // +/-, and 6 digit weight
            const int decimalPositionIndex = 8; // index from 0x02
            static Regex rx = new Regex(@"\x02[+-][0-9]{6}[0-4][0-9A-F]{2}\x03", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            static string fragmentString = "";  // If one data is notified by multiple events, or if a data fragment remain at the end.
            static void Main(string[] args)
            {
                // The following ReadTextAll() simulates SerialPort.ReadExisting().
                string readExsistingString = File.ReadAllText(args[0]);
                if (readExsistingString.Length > 0)
                {
                    List<string> foundList = GetAvailableDataList(readExsistingString, ref fragmentString);
                    foreach (string foundString in foundList)
                    {
                        Console.WriteLine("Received:{0}", foundString);
                    }
                    if (fragmentString.Length > 0)
                    {
                        Console.WriteLine("IncompletedData:{0}", fragmentString);
                    }
                }
            }
            static List<string> GetAvailableDataList(string inputString, ref string fragmentString)
            {
                List<string> resultList = new List<string>();
                if (inputString.Length >= singleDataLength)
                {
                    int lastSTXIndex = inputString.LastIndexOf('\x02');
                    if (lastSTXIndex >= 0)
                    {
                        MatchCollection mc = rx.Matches(inputString);
                        foreach (Match m in mc)
                        {
                            if (m.Success)
                            {
                                // ToDo: XRL check must be implemented
                                // bool checked = checkXRL(m.Value);
                                // if (checked)
                                // {
                                    string formatedData = m.Value.Substring(1, weightDataLength);
                                    int decimalPoint = int.Parse(m.Value.Substring(decimalPositionIndex, 1));
                                    if (decimalPoint > 0)
                                    {
                                        formatedData = formatedData.Insert((weightDataLength - decimalPoint), ".");
                                    }
                                    resultList.Add(formatedData);
                                    if (m.Index == lastSTXIndex)
                                    {
                                        lastSTXIndex = -1;
                                    }
                                // }
                            }
                        }
                    }
                    if (lastSTXIndex >= 0)
                    {
                        fragmentString = inputString.Substring(lastSTXIndex);
                    }
                    else
                    {
                        fragmentString = "";
                    }
                }
                return resultList;
            }
        }
    }
