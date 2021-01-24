    using (CsvFileReader reader = new CsvFileReader(filePath))
                {
					List<MyMappedCSVFile> lst=new List<MyMappedCSVFile>();
                    CsvRow row = new CsvRow();
                    while (reader.ReadRow(row))
                    {  
                        if (row[0].Equals("TransactionID")) //to skip header
                            continue;
                        else
                        {
						   MyMappedCSVFile obj=new MyMappedCSVFile();
						   obj.ProfileID =row[1]; //Column Index of ProfileID
						   obj.Date = row[2]; // Column index of Date 
						   lst.Add(obj);
                        }
					}
				}  
