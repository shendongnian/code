    Dictionary<string, string> erroredLines = new Dictionary<string, string>();
    
    foreach (var line in this.FileLines)
        {
            count++;
    
            string[] bits = line.Split(',');
            fineNumber = bits[0].Trim();
            int length = bits.Length;
            if (length == 9)
            {
                //other processing gets done here, code not included as its of no interest for this question
            }
            else
            {
                //AddErrorFinesToFile(line, fineNumber);
                AddFinesToDictonary(fineNumber, line);
                continue;
            }
        }
     
    
       
    
    public void AddFinesToDictonary(string fineNumber, string errorLine)
        {
                   erroredLines.Add(fineNumber, errorLine);
           // return erroredLines;
        }
