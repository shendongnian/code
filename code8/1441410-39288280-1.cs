            foreach (string line in lines)
            {
                List<string> linesColumns = new List<string>();
                int lastIndex = 0;
                foreach (int maxLength in maxLengths)
                { 
                   linesColumns.Add( line.Substring(lastIndex, maxLength));
                   lastIndex += maxLength;
                }
            }
