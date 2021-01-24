            var match = false;
            for (int i = 0; i < xlRange.Rows.Count; i++)
            {
                
                IPAddress excelIP;
                if (IPAddress.TryParse(xlWorksheet.Cells[i + 1, 1].Value.ToString(), out excelIP))
                {
                    if (excelIP.ToString().Equals(addr))
                    {
                        match = true;
                        Console.Write(excelIP.ToString());
                        Console.WriteLine(" -This id was found");
                    }
                }
            }
            if (!match)
            {
                Console.WriteLine("No Match ");
            }
