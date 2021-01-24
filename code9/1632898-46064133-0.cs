    // HelperClass.cs
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfCsvSkipTicker
    {
        public static class HelperClass
        {
            public static  List<ItemGrid> ReadCsv(string filepath)
            {
                if (!File.Exists(filepath)) return null;
                var allLines = File.ReadAllLines(filepath);
                var result =
                    from line in allLines.Skip(1).Take(allLines.Length -2)
                    let temparry = line.Split(';')
                    let isSkip =
                        temparry.Length > 1
                        && temparry[1] != null
                        && temparry[1] == "X"
                    select new ItemGrid { ItemName = temparry[0], ItemValue = !isSkip };
                return result.ToList();
            }
    
            public static void WriteCsv(IEnumerable<ItemGrid> items, string filepath)
            {
                var temparray = items.Select(item => item.ItemName + ";" + (item.ItemValue ? "" : "X")).ToArray();
                var contents = new string[temparray.Length + 2];
                Array.Copy(temparray, 0, contents, 1, temparray.Length);
                contents[0] = "SFOBject;Skip";
                contents[contents.Length - 1] = "SuccessMSG;";
                File.WriteAllLines(filepath, contents);
            }
        }
    
        public class ItemGrid
        {
            public string ItemName { set; get; }
            public bool ItemValue { set; get; }
        }
    }
