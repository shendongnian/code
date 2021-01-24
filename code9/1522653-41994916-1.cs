    FileStream fs = File.Open(@"D:\Example1.txt", FileMode.Open);
           List<RowData> lstLines = new List<RowData>();
            using (StreamReader stRead = new StreamReader(fs))
            {
                RowData oRowData = null;
                while (!stRead.EndOfStream)
                {
                    string sLine = stRead.ReadLine();
                    if (sLine.IndexOf("Start Time") > -1)
                    {
                        if (oRowData != null)
                        {
                            lstLines.Add(oRowData);
                        }
                        oRowData = new RowData();
                        oRowData.StartTime = sLine;
                    }
                    if (sLine.IndexOf("Workstation") > -1)
                    {
                        if (oRowData != null)
                        {
                            oRowData.Workstation = sLine.Remove('.');
                        }
                    }
                }
            }
