    using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
                {
                    string filenameDate = FileUpload1.FileName.Substring(15, 2);
                    Dictionary<string, int> dMyobject = new Dictionary<string, int>();
    
                    while (!stRead.EndOfStream)
                    {
                        var readedLine = stRead.ReadLine();
    
                        if (!string.IsNullOrWhiteSpace(readedLine))
                        {
    
                            //int readedLineTime = Convert.ToInt32(readedLine.Substring(09, 02));
                            string sDate = readedLine.Substring(0, 11);
    
                            
                MatchCollection collection = Regex.Matches(readedLine, "(?<c>[A-Z]+);");
    
                            if (!dMyobject.Keys.Contains(sDate))
                            {
                                dMyobject.Add(sDate, GetTotal(collection));
                            }
                            else
                            {
                                dMyobject[sDate] = dMyobject[sDate] + GetTotal(collection);
                            }
    
    
                        }
                        textfileContent += readedLine + Environment.NewLine;
                        i++;
                    }
                    txtContent.Text = textfileContent;
                    lblLineCount.Text = i.ToString();
                    //Label1.Text =  this.TextBox1.Text.Split(new Char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
                    lblFileDate.Text = filenameDate;
    
    
    
    
                    foreach (var item in dMyobject)
                    {
                        textfileOutput += (item.Key + "  " + item.Value) + Environment.NewLine;
                        //  textfileOutput += (item.Value) + Environment.NewLine;
                    }
                    txtOutput.Text = textfileOutput;
    
    
    
                }
    
    
    //this method is a new method, it got total score, and if you rule chanage you can set `D` +1, `A` +2 etc.
            private int GetTotal(MatchCollection collection)
            {
                Dictionary<string, int> point = new Dictionary<string, int>();
                point["D"] = 1;
                point["A"] = 0;
    
                int total = 0;
                foreach (Match m in collection)
                {
                    string str = m.Groups["c"].Value;
                    if (point.ContainsKey(str))
                        total += point[str];
                }
                return total;
            }
