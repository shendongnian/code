     string orignalString = "";
     orignalString = pt;
     char[] buffer = pt.ToCharArray();
     orignalString = new string(buffer);
     return orignalString.Replace(" ", string.Empty);
     // Here I got the string without spaces , now I have the same string with and without spaces
