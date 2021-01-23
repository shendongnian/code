    List<string> dividers = new List<string>{".","/","-"}
    
    private void comboBox_DateFormatDivider_SelectedIndexChanged(object sender, EventArgs e)
    {
        string currentSeparator = string.Empty;
        
         foreach(var s in dividers)
         {
         string pattern = @".*(?:\" + s + ").*";
         
            if(Regex.IsMatch(_dateFormatsList[0],pattern))
            {
              currentSeparator = s;
              break;    
             }    
         }
        for (int i = 0; i < _dateFormatsList.Count; i++)
        {
            _dateFormatsList[i] = _dateFormatsList[i].Replace(currentSeparator, comboBox_DateFormatDivider.SelectedText);
        }
    }
