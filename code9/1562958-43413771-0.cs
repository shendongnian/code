    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static int[] COLUMN_WIDTHS = { 9, 7, 7, 7, 9, 9};
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("No. Plate", typeof(int));
                dt.Columns.Add("Plate Type", typeof(string));
                dt.Columns.Add("Plate Id", typeof(int));
                dt.Columns.Add("No. Coord", typeof(int));
                dt.Columns.Add("X-Coord", typeof(double));
                dt.Columns.Add("Y-Coord", typeof(double));
                int noPlate = 0;
                string plateType = "";
                int plateId = 0;
                int noCoord = 0;
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    if (!inputLine.StartsWith("*"))
                    {
                        string[] splitArray = FixedColumns(inputLine);
                        DataRow newRow = dt.Rows.Add();
                        if (splitArray[0].Trim().Length > 0)
                        {
                            noPlate = int.Parse(splitArray[0]);
                        }
                        newRow["No. Plate"] = noPlate;
                        if (splitArray[1].Trim().Length > 0)
                        {
                            plateType  = splitArray[1];
                        }
                        newRow["Plate Type"] = plateType;
                        if (splitArray[2].Trim().Length > 0)
                        {
                            plateId  = int.Parse(splitArray[2]);
                        }
                        newRow["Plate Id"] = plateId;
                        
                        if (splitArray[3].Trim().Length > 0)
                        {
                            noCoord  = int.Parse(splitArray[3]);
                        }
                        newRow["No. Coord"] = noCoord;
                        
                        newRow["X-Coord"] = double.Parse(splitArray[4]);
                        newRow["y-Coord"] = double.Parse(splitArray[5]);
                    }
                }
     
            }
            static string[] FixedColumns(string input)
            {
                string[] splitArray = new string[COLUMN_WIDTHS.Length];
                int startCol = 0;
                for (int i = 0; i < COLUMN_WIDTHS.Length; i++)
                {
                    if (i < COLUMN_WIDTHS.Length - 1)
                    {
                        splitArray[i] = input.Substring(startCol, COLUMN_WIDTHS[i]).Trim();
                    }
                    else
                    {
                        splitArray[i] = input.Substring(startCol).Trim();
                    }
                    startCol += COLUMN_WIDTHS[i];
                }
                return splitArray;
            }
        }
    }
