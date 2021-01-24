    List<DrawNew> ObservingData = new List<DrawNew>(); // List to store all available DrawNew objects from the CSV
    
                // Loops through each lines in the CSV
                var fileName = "";
                var previousPassValue = true;
                var count = 0;
                foreach (string line in System.IO.File.ReadAllLines(outputFilePath.Text).Skip(1)) // .Skip(1) is for skipping header
                {
                    string[] valuesCsvLine = line.Split(',');
                    DrawNew mngInstance = new DrawNew();
    
                    mngInstance.Date = DateTime.ParseExact(valuesCsvLine[0], dateFormatString, CultureInfo.InvariantCulture);
                    mngInstance.Pass = (valuesCsvLine[1] == "TRUE" ? true : false);
                    mngInstance.CutMark1 = (valuesCsvLine[2] == "TRUE" ? true : false);
                    mngInstance.Marks1 = (valuesCsvLine[3] == "TRUE" ? true : false);
                    mngInstance.CutMark2 = (valuesCsvLine[4] == "TRUE" ? true : false);
                    mngInstance.Marks2 = (valuesCsvLine[5] == "TRUE" ? true : false);
                    if (count == 0)
                    {
                        previousPassValue = mngInstance.Pass;
                        count++;
                    }
                    
                    if (previousPassValue != mngInstance.Pass)
                    {
                        count++;
                    }
    
                    if (mngInstance.Pass == true && mngInstance.Marks1 == true)
                    {
                        fileName = "Charge" + count + "_Mark1.csv";
    
                    }
                    if (mngInstance.Pass == false && mngInstance.Marks1 == true)
                    {
                        fileName = "DisCharge" + count + "_Mark1.csv";
                    }
                    if (mngInstance.Pass == true && mngInstance.Marks2 == true)
                    {
                        fileName = "Charge" + count + "_Mark2.csv";
                    }
                    if (mngInstance.Pass == false && mngInstance.Marks2 == true)
                    {
                        fileName = "DisCharge" + count + "_Mark2.csv";
                    }
    
                    mngInstance.FileName = fileName;
    
                    ObservingData.Add(mngInstance);
                }
