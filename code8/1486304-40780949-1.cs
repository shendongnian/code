    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using OfficeOpenXml;
    
    namespace TestC
    {
        public class PostData
        {
            public string DocumentName { get; set; }
            public DateTime ActionDate { get; set; }
            public string ActionType { get; set; }
            public string ActionPerformedBy { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (ExcelPackage package = new ExcelPackage()) {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    string jsonData = @"[
                        {
                            ""DocumentName"": ""Test Document"",
                            ""ActionDate"": ""2015-09-25T16:06:25.083"",
                            ""ActionType"": ""View"",
                            ""ActionPerformedBy"": ""Sreeja SJ""
                        },
                        {
                            ""DocumentName"": ""Test Document"",
                            ""ActionDate"": ""2015-09-25T16:12:02.497"",
                            ""ActionType"": ""View"",
                            ""ActionPerformedBy"": ""Sreeja SJ""
                        },
                        {
                            ""DocumentName"": ""Test Document"",
                            ""ActionDate"": ""2015-09-25T16:13:48.013"",
                            ""ActionType"": ""View"",
                            ""ActionPerformedBy"": ""Sreeja SJ""
                        }]";
    
                    List<PostData> dataForExcel = JsonConvert.DeserializeObject<List<PostData>>(jsonData);
    
                    worksheet.Cells[1, 1].LoadFromCollection(dataForExcel, true);
    
                    package.SaveAs(File.Create(@"C:\Users\User\Documents\sample.xlsx"));
                }
            }
        }
    }
