    DateTime outDate = new DateTime();
    string[] words = columnName.Split(' ');
    if(words.Length>1){
       string month = words[0].Substring(0,3);
       string year = words[1];
       outDate = DateTime.ParseExact(month+' '+year, 
       "MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }
