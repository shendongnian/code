            var result = new List<DataRow>();
            //convert to list to avoid multiple enumerations
            var table2List = Table2.AsEnumerable().ToList();
            
            foreach(var row in Table1.AsEnumerable())
            {
                var matchingRow = table2List.FirstOrDefault(x => x["CarReg"] == row["CarReg"]);
                
                if(matchingRow == null)
                {
                    result.Add(row);
                }
            }  
