    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Web.Http;
    // NOTE: This is not purely my code. This was put together
    // with the help of other SO questions that I wish I had the
    // links to so I could credit them. You probably will find
    // some chunk(s) of this code elsewhere on SO.
    
    namespace Application1.Controllers
    {
        public class Foo
        {
            public string Csv { get; set; }
        }
        public class JsonController : ApiController
        {
            [HttpPost]
            [Route("~/Csv/ToJson")]
            public dynamic[] ConvertCsv([FromBody] Foo input)
            {
                var data = CsvToDynamicData(input.Csv);
                return data.ToArray();
            }
    
            internal static List<dynamic> CsvToDynamicData(string csv)
            {
                var headers = new List<string>();
                var dataRows = new List<dynamic>();
                using (TextReader reader = new StringReader(csv))
                {
                    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader))
                    {
                        parser.Delimiters = new[] {","};
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.TrimWhiteSpace = true;
    
                        var rowIdx = 0;
    
                        while (!parser.EndOfData)
                        {
                            var colIdx = 0;
                            dynamic rowData = new ExpandoObject();
                            var rowDataAsDictionary = (IDictionary<string, object>) rowData;
    
                            foreach (var field in parser.ReadFields().AsEnumerable())
                            {
                                if (rowIdx == 0)
                                {
                                    // header
                                    headers.Add(field.Replace("\\", "_").Replace("/", "_").Replace(",", "_"));
                                }
                                else
                                {
                                    if (field == "null" || field == "NULL")
                                    {
                                        rowDataAsDictionary.Add(headers[colIdx], null);
                                    }
                                    else
                                    {
                                        rowDataAsDictionary.Add(headers[colIdx], field);
                                    }
                                    
                                }
                                colIdx++;
                            }
    
                            if (rowDataAsDictionary.Keys.Any())
                            {
                                dataRows.Add(rowData);
                            }
    
                            rowIdx++;
                        }
                    }
                }
    
                return dataRows;
            }
        }
    }
