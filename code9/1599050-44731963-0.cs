    string json = "";
    for (int i = 0; i < array.Count; i++){
        MyObject t = array[i];
        json += new JavaScriptSerializer().Serialize(t);
    }
    
    string pattern = "\}{\";
    string replacement = "},{";
    Regex rgx = new Regex(pattern);
    string result = rgx.Replace(json, replacement);
