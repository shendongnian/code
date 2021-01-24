    using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
              
                Dictionary<string, int> dMyobject = new Dictionary<string, int>();
    
                while (!stRead.EndOfStream)
                {
                    var readedLine = stRead.ReadLine();
                    if (!string.IsNullOrWhiteSpace(readedLine))
                    {
                        //int readedLineTime = Convert.ToInt32(readedLine.Substring(11, 02));
                        string sDate = readedLine.Substring(11, 2);
    
                        MatchCollection collection = Regex.Matches(readedLine, @"D;");
                        countedChars = collection.Count;
    
  
                        if (!dMyobject.Keys.Contains(sDate))
                        {
                            dMyobject.Add(sDate, collection.Count);
                        }
                        else
                        {
                            dMyobject[sDate] = dMyobject[sDate] + collection.Count;
                        }
                    }
                    textfileContent += readedLine + Environment.NewLine;
                    i++;
                }
                txtContent.Text = textfileContent;
                lblLineCount.Text = i.ToString();
                
           
    
                var prevDate = string.Empty; 
                int tester = 01;
    
                foreach (var item in dMyobject)
                {
                    int testCorrectStart = Convert.ToInt32(item.Key) - tester;
                    if (testCorrectStart == 0)
                    {
                        if (!string.IsNullOrEmpty(prevDate))
                        {
                            var cur = Int32.Parse(item.Key); // convert current key into int
                            var prev = Int32.Parse(prevDate);
                            int dayDiff = cur - prev;
                            for (var x = 0; x < dayDiff - 1; x++) // run through day difference, add it to the last date that was added
                            {
    
                                textfileOutput += ((prev + (x + 1)).ToString() + "  0" + Environment.NewLine);
    
                            }
                        }
                        textfileOutput += (item.Key + "  " + item.Value) + Environment.NewLine;
                        prevDate = item.Key;
                        tester++;
                    }
    
                    else
                    {
 
                        if (!string.IsNullOrEmpty(tester.ToString()))
                        {
                            var cur = Int32.Parse(item.Key); // convert current key into int
                            var prev = Int32.Parse(tester.ToString());
                            int dayDiff = cur - prev;
                            for (var x = 0; x < dayDiff ; x++) // run through day difference, add it to the last date that was added
                            {
    
                                textfileOutput += ("0" +(prev + x).ToString() + "  0" + Environment.NewLine);
                            }
                        }
                        textfileOutput += (item.Key + "  " + item.Value) + Environment.NewLine;
                        prevDate = item.Key;
                        tester = Convert.ToInt32(prevDate) + 1;
                    }
                }
                txtOutput.Text = textfileOutput;
            }
