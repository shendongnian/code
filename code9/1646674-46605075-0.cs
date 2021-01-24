    var str="abcdabcd";
    
    for (int i = 0; i < str.Length; i++)
    {
       String ch = str[i].ToString();
    
       for (int j = 0; j < l; j++)
       {
          if (ch == str[j].ToString())
          {
             break;
          }
          else
          {
             Response.Write("First Non repeating character : " + ch.ToString());
             return;
          }
       }
    }
