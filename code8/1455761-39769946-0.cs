      string longestName = "";
        foreach (string possibleDate in comboBox1.Items){
           if(longestName.Length < possibleDate.Length){
              longestName = possibleDate;
           }
        }
