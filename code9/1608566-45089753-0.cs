    string newString = "";
    StreamReader sr = new StreamReader('log.txt');
    while(!sr.ReadLine)
    {
       string[] splitted = sr.ReadLine().Split('/');
       if(splitted.Length > 0)
            newString += splitted[splitted.Length - 1];
    }
    sr.Close();
