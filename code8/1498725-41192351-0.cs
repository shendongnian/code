     string strValue = "19345abc#/";
     char[] charArray = strValue.ToCharArray();
     List<int> list = new List<int>();
     for (int i = 0; i < charArray.Length; i++)
         {
           if (char.IsNumber(charArray[i]))
             {
               list.Add(charArray[i] - '0');
             }
         }
