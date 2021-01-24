    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DemoProject
    {
        public class DataFile
        {
            public DataFile()
            {
                this.Entries = new List<DataEntry>();
            }
            public List<DataEntry> Entries
            {
                get;
            }
            public static DataFile Load(string fileName)
            {
                DataFile result = new DataFile();
                if(System.IO.File.Exists(fileName))
                {
                    string[] allLines = System.IO.File.ReadAllLines(fileName);
                    foreach (var line in allLines)
                    {
                        var splittedValues = line.Split(',');
                        DataEntry entry = new DataEntry();
                        entry.Station = splittedValues[0];
                        entry.Year = splittedValues[1];
                        entry.Number = splittedValues[2];
                        entry.January = splittedValues[3];
                        entry.February = splittedValues[4];
                        entry.March = splittedValues[5];
                        entry.April = splittedValues[6];
                        entry.Mai = splittedValues[7];
                        entry.Juni = splittedValues[8];
                        entry.Juli = splittedValues[9];
                        entry.August = splittedValues[10];
                        entry.September = splittedValues[11];
                        entry.October = splittedValues[12];
                        entry.November = splittedValues[13];
                        entry.December = splittedValues[14];
                    }
                }
                return result;
            }
            /// <summary>
            /// Returns true if all entries (all lines of the csv file) have the same station (the same first word).
            /// If one entry have another first word it returns false.
            /// </summary>
            /// <returns></returns>
            public bool CheckStation()
            {
                string station = string.Empty;
                bool firstEntry = true;
                foreach (var entry in this.Entries)
                {
                    if(firstEntry)
                    {
                        station = entry.Station;
                    }
                    else
                    {
                        if(entry.Station != station)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            /// <summary>
            /// Returns the entries of the file which have the same year as given.
            /// </summary>
            /// <param name="year"></param>
            /// <returns></returns>
            public DataEntry[] GetAllEntriesOfOneYear(string year)
            {
                return this.Entries.Where(p => p.Year == year).ToArray();
            }
            /// <summary>
            /// Returns true if this entries contains the same years as the entries of the given file
            /// If one file have one more or less year it returns false
            /// </summary>
            /// <param name="otherFile"></param>
            /// <returns></returns>
            public bool CheckYears(DataFile otherFile)
            {
                string[] allPossibleYearsOfThisFile = this.GetYears();
                string[] allPossibleYearsOfTheOtherFile = otherFile.GetYears();
                if(allPossibleYearsOfThisFile.Length != allPossibleYearsOfTheOtherFile.Length)
                {
                    return false;
                }
                else
                {
                    foreach (var year in allPossibleYearsOfThisFile)
                    {
                        if(!allPossibleYearsOfTheOtherFile.Contains(year))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            /// <summary>
            /// Returns all possible years of the entries.
            /// </summary>
            /// <returns></returns>
            public string[] GetYears()
            {
                return this.Entries.Select(p => p.Year).Distinct().ToArray();
            }
        }
    }
