    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace MdeLoadTest
    {
        class DataRow
        {
            public string Label { get; set; }
            public int Line { get; set; }
            public int PickupValue { get; set; }
            public int Type { get; set; }
            public int Value { get; set; }
        }
        class ParseData
        {
            private List<DataRow> rows;
            private int ReadSource(string file)
            {
                string[] fileLines = File.ReadAllLines(file);
    
    
                rows = new List<DataRow>();
                string fieldInfo, fieldValue, fieldName;
                int lineNumber, oldLineNumber;
                string[] splitLine;
                string[] fieldInfoParts;
                oldLineNumber = -1;
                DataRow row = null;
                foreach (string line in fileLines)
                {
                    
                    splitLine = line.Split('=');
                    fieldInfo = splitLine[0];                
                    fieldValue = splitLine.Count() >0? splitLine[1]:null;
                    fieldInfoParts = fieldInfo.Split('.');
    
                    lineNumber = int.Parse(fieldInfoParts[1]);
                    fieldName = fieldInfoParts[2];
    
                    if(lineNumber != oldLineNumber)
                    {
                        rows.Add(row);
                        row = new DataRow();
                        oldLineNumber = lineNumber;
                    }
                    switch (fieldName)
                    {
                        case "label":
                            row.Label = fieldValue;
                            break;
                        case "line":
                            row.Line = int.Parse(fieldValue);
                            break;
                        case "pickup_value":
                            row.PickupValue = int.Parse(fieldValue);
                            break;
                        case "type":
                            row.Type = int.Parse(fieldValue);
                            break;
                        case "value":
                            row.Value = int.Parse(fieldValue);
                            break;
                        default:
                            throw new Exception($"Unknown key:{fieldName}");
                    }
                }
                if (oldLineNumber != -1)
                {
                    rows.Add(row);
                }
                return rows.Count;
            }
    
            DataTable table;
            private void InitTable()
            {
                DataTable dt = new DataTable();
                // define structure
                dt.Columns.Add("Label",typeof(string));
                dt.Columns.Add("Line", typeof(int));
                dt.Columns.Add("PickupValue", typeof(int));
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("Value", typeof(int));
            }
    
            private void PopulateData ()
            {
                foreach (var row in rows)
                {
                    table.Rows.Add(row);
                }
            }
    
            public DataTable Load(string sourceFile)
            {
                if (ReadSource(sourceFile) < 1)
                    return null;
                InitTable();
                PopulateData();
    
                return table;
            }
        }
    }
