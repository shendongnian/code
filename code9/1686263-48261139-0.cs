    private DataTable GetDataFromSource(string connectionstring)
        {
             DataTable DtCsv = new DataTable();  
             string Fulltext;
            
                using (StreamReader sr = new StreamReader(connectionstring))
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                        string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                            {
                                if (i == 0)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        DtCsv.Columns.Add(rowValues[j]); //add headers  
                                    }
                                }
                                else
                                {
                                    DataRow dr = DtCsv.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }
                                    DtCsv.Rows.Add(dr); //add other rows  
                                }
                            }
                        }
                    }
                }
            
            return DtCsv;
        }
