    List<String> numericValues = new List<String>();
    String tempValue = String.Empty;
    
    for(int i =0; i < sourceString.length;i++)
    {
       if(Char.IsDigit(sourcestring[i]) || sourcestring[i] == '/' || sourcestring[i] == '$')//Etc.. special characters
       {
         tempValue = tempValue  + sourcestring[i]
       }
       else
       {
          if(tempValue != String.Empty)
          {
             numericValues.Add(tempValue);
             tempValue = String.Empty
          }
       }
    }
