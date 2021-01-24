    String getArr = my_string.Replace('%', '/');
    String[] splt = getArr.Split('/');
    
    if (int.Parse(splt[1].ToString()) > 95)
     { 
        splt[1] = "High";
     }
     string result = splt[0] + splt[1] + splt[2];
