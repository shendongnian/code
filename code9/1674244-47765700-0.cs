    using ExcelDataReader;
    using System.Collections.Generic;
    using System.IO;
    
    namespace Test.Data.Excel
    {
        public class Reader
        {
            public static IEnumerable<object[]> Read(string filePath)
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var count = reader.FieldCount;
                        do
                        {
                            var list = new List<object>();
                            while (reader.Read())
                            {
                                list.Add(reader.GetString(0));
                            }
                            yield return list.ToArray();
    
                        } while (reader.NextResult());
                    }
                }
            }
        }
    }
