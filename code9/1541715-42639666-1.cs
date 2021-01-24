        public static void DicToExcel(Dictionary<string, List<string>> dict, string path)
        {
                //We will put all results here in StringBuilder and just append everything
                StringBuilder sb = new StringBuilder();
                //The key will be our header
                String csv = String.Join(",",
                       dict.Select(d => d.Key));
                sb.Append(csv + Environment.NewLine);
                
                //We will take every string by element position
                String csv1 = String.Join(",",
                       dict.Select(d => string.Join(",", d.Value.First().Take(1))));
                sb.Append(csv1 + Environment.NewLine);
                
                String csv2 = String.Join(",",
                       dict.Select(d => string.Join(",", d.Value.Skip(1).Take(1))));
                sb.Append(csv2+ Environment.NewLine);
                String csv3 = String.Join(",",
                     dict.Select(d => string.Join(",", d.Value.Skip(2).Take(1))));
                sb.Append(csv3);
                //Write the file
                System.IO.File.WriteAllText(path, sb.ToString());
        }
