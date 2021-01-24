        var csv = new StringBuilder();
            var myQueriedList= ObserveData.Where(p => p.pass == true);
            
            foreach (var value in myQueriedList)
            {
                //comma deliminated csv
                csv.Append(value).Append(",");            
            }
      File.WriteAllText(filePath, csv.ToString());
