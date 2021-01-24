        public static MultiValueDictionary<string, ILookup<string, string>> ParseTemplate(string Sheet, ref List<string> keys)
        {
            int xskip = 0;
            MultiValueDictionary<string, ILookup<string, string>> mvd = new MultiValueDictionary<string, ILookup<string, string>>();
            var sheetRows = Book.Tables[Sheet];
            //Parse First row
            var FirstRow = sheetRows.Rows[0];
            for (var Columns = 0; Columns < sheetRows.Columns.Count; Columns++)
            {
                if (xskip == 0)
                {
                    xskip = 1;
                    continue;
                }
                keys.Add(FirstRow[Columns].ToString());
            }
            //Skip First Row
            xskip = 0;
            //Create a binding of first row and all subsequent rows
            foreach (var row in sheetRows.Select().Skip(1))
            {
                //Make the key the first cell of each row
                var key = row[0];
                List<string> rows = new List<string>();
                foreach (var item in row.ItemArray)
                {
                    if (xskip == 0)
                    {
                        xskip = 1;
                        continue;
                    }
                    rows.Add(item.ToString());
                }
                mvd.Add(key.ToString(), keys.Zip(rows, (m, n) => new { Key = m, Value = n }).ToLookup(x => x.Key, y => y.Value));
                xskip = 0;
            }
            return mvd;
        }
    }
    //This is example of what a function to parse this could do.
    foreach(var Key in mvd.Keys)
    {
         var KeywithValues = mvd[Key];
         foreach(ColumnName in Keys)
         {
             KeywithValues[ColumnName].
         }
    }
