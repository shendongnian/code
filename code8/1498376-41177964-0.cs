    public void ListValue()
      {
        if (vbCodes.Count > 0)
          {
             StringBuilder strBuilder = new StringBuilder();
             foreach (var item in vbCodes)
               {
                 strBuilder.Append(item.Formula).Append(" || ");
               }
             string strFuntionResult = strBuilder.ToString();
          }
       }
