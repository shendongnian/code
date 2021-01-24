     private static List<string> ToListString(IEnumerable<object[]> inparam)
        {
            var custNums = new List<string>();
            foreach (var row in inparam)
            {
                if (row[0] != null && row[0] != DBNull.Value)
                    custNums.Add(row[0].ToString());
            }
            return custNums;
        }
