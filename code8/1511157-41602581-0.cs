    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication41
    {
        class Program
        {
            static void Main(string[] args)
            {
                Data.data = new List<Data>() {
                    new Data() { ID = 1, TagID = 1, RelatedTagID = 2},
                    new Data() { ID = 2, TagID = 2, RelatedTagID = 1},
                    new Data() { ID = 3, TagID = 1, RelatedTagID = 3},
                    new Data() { ID = 4, TagID = 3, RelatedTagID = 1},
                    new Data() { ID = 5, TagID = 2, RelatedTagID = 3},
                    new Data() { ID = 6, TagID = 3, RelatedTagID = 2}
                };
                var results = Data.data.GroupBy(x => x.RelatedTagID)
                    .OrderBy(x => x.Key)
                    .Select(x => new {
                        ID = x.Key,
                        RelatedTagKeys = x.Select(y => y.TagID).ToList()
                    }).ToList();
                foreach (var result in results)
                {
                    Console.WriteLine("ID = '{0}', RelatedTagKeys = '{1}'", result.ID, string.Join(",",result.RelatedTagKeys.Select(x => x.ToString())));
                }
                Console.ReadLine();
            }
        }
        public class Data
        {
            public static List<Data> data { get; set; }
            public int ID { get; set; }
            public int TagID { get; set; }
            public int RelatedTagID { get; set; }
        }
    }
