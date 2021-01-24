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
                            oRowData = null;
                        }
                        oRowData = new RowData();
                        sLine = sLine.Replace(".", "");
                        sLine = sLine.Replace("Start Time", "");
                        oRowData.StartTime = sLine;    
                    }
                    if (sLine.IndexOf("Workstation") > -1)
                    {
                        if (oRowData != null)
                        {
                            sLine = sLine.Replace(".", "");
                            sLine = sLine.Replace("Workstation", "");
                            oRowData.Workstation = sLine;
                        }
                    }
                }
            }
