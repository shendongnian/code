    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace pivot
    {
        class Program
        {
            static void Main(string[] args)
            {
                var _staticColumnCount = 2; //Columns that should not be pivoted        
                var _dynamicColumnCount = 2; // Columns which needs to be pivoted to form header            
                var _valueColumnCount = 1; //Columns that represent Actual value        
                var valueColumnIndex = 4; //Assuming index starts with 0;
    
                List<List<string>> headerInfo = new List<List<string>>();
                headerInfo.Add(new List<string> { "Product Three", "Item Three" });
                headerInfo.Add(new List<string> { "Product Two", "Item Five" });
                headerInfo.Add(new List<string> { "Product Two", "Item Seven" });
                headerInfo.Add(new List<string> { "Product Two", "Item Nine" });
                headerInfo.Add(new List<string> { "Product One", "Item One" });
                headerInfo.Add(new List<string> { "Product One", "Item Two" });
                headerInfo.Add(new List<string> { "Product One", "Item Four" });
                headerInfo.Add(new List<string> { "Product One", "Item Six" });
                headerInfo.Add(new List<string> { "Product One", "Item Eight" });
                headerInfo.Add(new List<string> { "Product One", "Item Eleven" });
                headerInfo.Add(new List<string> { "Product Three", "Item Ten" });
    
    
                List<List<string>> data = new List<List<string>>();
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item One", "579984.59" });
                data.Add(new List<string> { "Global", "North America", "Product One", "Item Two", "314586.73" });
                data.Add(new List<string> { "Global", "Asia", "Product One", "Item One", "62735.13" });
                data.Add(new List<string> { "Global", "Asia", "Product Two", "Item Five", "12619234.69" });
                data.Add(new List<string> { "Global", "North America", "Product Two", "Item Five", "8953713.39" });
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item Two", "124267.4" });
                data.Add(new List<string> { "Global", "Asia", "Product One", "Item Four", "482338.49" });
                data.Add(new List<string> { "Global", "North America", "Product One", "Item Four", "809185.13" });
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item Four", "233101" });
                data.Add(new List<string> { "Global", "Asia", "Product One", "Item Two", "120561.65" });
                data.Add(new List<string> { "Global", "North America", "Product One", "Item Six", "1517359.37" });
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item Six", "382590.45" });
                data.Add(new List<string> { "Global", "North America", "Product One", "Item Eight", "661835.64" });
                data.Add(new List<string> { "Global", "Europe", "Product Three", "Item Three", "0" });
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item Eight", "0" });
                data.Add(new List<string> { "Global", "Europe", "Product Two", "Item Five", "3478145.38" });
                data.Add(new List<string> { "Global", "Asia", "Product One", "Item Six", "0" });
                data.Add(new List<string> { "Global", "North America", "Product Two", "Item Seven", "4247059.97" });
                data.Add(new List<string> { "Global", "Asia", "Product Two", "Item Seven", "2163718.01" });
                data.Add(new List<string> { "Global", "Europe", "Product Two", "Item Seven", "2158782.48" });
                data.Add(new List<string> { "Global", "North America", "Product Two", "Item Nine", "72634.46" });
                data.Add(new List<string> { "Global", "Europe", "Product Two", "Item Nine", "127500" });
                data.Add(new List<string> { "Global", "North America", "Product One", "Item One", "110964.44" });
                data.Add(new List<string> { "Global", "Asia", "Product Three", "Item Ten", "2064.99" });
                data.Add(new List<string> { "Global", "Europe", "Product One", "Item Eleven", "0" });
                data.Add(new List<string> { "Global", "Asia", "Product Two", "Item Nine", "1250" });
    
                Reducer reducer = new Reducer();
                reducer.headerCount = headerInfo.Count;
    
                reducer.headerCount = headerInfo.Count;
                var resultCount = (int)Math.Ceiling((double)data.Count / (double)reducer.headerCount);
    
                ValueArray[,] results = new ValueArray[resultCount, _staticColumnCount + reducer.headerCount];
    
                reducer.headerDict = new Dictionary<IEnumerable<string>, int>(new MyComparer());
                reducer.skipCols = _staticColumnCount;
                reducer.headerKeys = _dynamicColumnCount;
                reducer.rowDict = new Dictionary<IEnumerable<string>, int>(new MyComparer());
                reducer.currentLine = 0;
                reducer.valueCount = _valueColumnCount;
                for (int i = 0; i < reducer.headerCount; i++)
                {
                    reducer.headerDict.Add(headerInfo[i], i);
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                results = data.Aggregate(results, reducer.reduce);
                stopwatch.Stop();
                Console.WriteLine("millisecs: " + stopwatch.ElapsedMilliseconds);
                for (int i = 0; i < resultCount; i++)
                {
                    var curr_header = new string[reducer.headerCount];
                    IEnumerable<string> curr_key = null;
                    for (int j = 0; j < reducer.headerCount; j++)
                    {
                        curr_header[j] = "[" +
                            String.Join(",", (results[i, reducer.skipCols + j]?.values) ?? new string[0])
                            + "]";
                        curr_key = curr_key ?? (results[i, reducer.skipCols + j]?.row_keys);
                    }
                    Console.WriteLine(String.Join(",", curr_key)
                        + ": " + String.Join(",", curr_header)
                        );
                }
                Console.ReadKey();
            }
            internal class ValueArray
            {
                internal IEnumerable<string> row_keys;
                internal string[] values;
            }
    
            internal class Reducer
            {
                internal int headerCount;
                internal int skipCols;
                internal int headerKeys;
                internal int valueCount;
                internal Dictionary<IEnumerable<string>, int> headerDict;
                internal Dictionary<IEnumerable<string>, int> rowDict;
                internal int currentLine;
                internal ValueArray[,] reduce(ValueArray[,] results, List<string> line)
                {
                    var header_col = headerDict[line.Skip(skipCols).Take(headerKeys)];
                    var row_keys = line.Take(skipCols);
    
                    var curr_values = new string[valueCount];
                    for (int i = 0; i < valueCount; i++)
                    {
                        curr_values[i] = line[skipCols + headerKeys + i];
                    }
    
                    if (rowDict.ContainsKey(row_keys))
                    {
                        results[rowDict[row_keys], skipCols + header_col] = new ValueArray();
                        results[rowDict[row_keys], skipCols + header_col].row_keys = row_keys;
                        results[rowDict[row_keys], skipCols + header_col].values = curr_values;
                    }
                    else
                    {
                        rowDict.Add(row_keys, currentLine);
                        results[currentLine, skipCols + header_col] = new ValueArray();
                        results[currentLine, skipCols + header_col].row_keys = row_keys;
                        results[currentLine, skipCols + header_col].values = curr_values;
                        currentLine++;
                    }
                    return results;
                }
            }
    
            public class MyComparer : IEqualityComparer<IEnumerable<string>>
            {
                public bool Equals(IEnumerable<string> x, IEnumerable<string> y)
                {
                    return x.SequenceEqual(y);
                }
    
                public int GetHashCode(IEnumerable<string> obj)
                {
                    return obj.First().GetHashCode();
                }
            }
    
        }
    }
