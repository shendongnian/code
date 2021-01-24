    //Assuming your data is stored in a file "yourdatafile"
    //Splitting all the text on "$" assuming this will separate GPSData
    string[] splittedstring = File.ReadAllText("yourdatafile").Split('$');
    //I found an extra string lingering in the sample you provided
    //because I splitted on "$", so you gotta take that into account
    var GPSList = new List<string>();
    var WAVList = new List<string>();
    foreach (var str in splittedstring)
    {
        //So if the string contains "Header" we would want to separate it from GPS data
        if (str.Contains("Header"))
        {
           string temp = str.Remove(str.IndexOf("Header"));
           int indexOfAsterisk = temp.LastIndexOf("*");
           string stringBeforeAsterisk = str.Substring(0, indexOfAsterisk + 1);
           string stringAfterAsterisk = str.Replace(stringBeforeAsterisk, "");
           WAVList.Add(stringAfterAsterisk);
           GPSList.Add("$" + stringBeforeAsterisk);
        }
        else
           GPSList.Add("$" + str);
    }
