            string sRowEnd = @"\cell\row";
            string sFormattedColumn = sStart;
            string sRow = string.Empty;
            
            for(int i = 0; i < nlines; i++) {
                sRow = sRowStart + values[i] + sRowEnd;
                sFormattedColumn += sRow;
            }
            
            sFormattedColumn += sEnd;
            return sFormattedColumn;
        }
        
        int NumLines(string sValue)
        {
            string[] values = sValue.Split('\r');
            return values.Length;
        }
        string[] Values(string sValue)
        {
            string[] values = sValue.Split('\r');
            for(int i = 0; i < values.Length; i++) {
                values[i] = values[i].Replace("\n", "");
            }
            
            return values;
        }
