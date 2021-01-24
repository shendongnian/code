    string[] splitted = rawResponse.Split(new char[] { '\r', '\n' });
    string aa = null;
    if (splitted[splitted.Length-1].Contains("%"))
    {
        aa = aa + splitted[splitted.Length-1];
    }
    
    string s = System.Uri.UnescapeDataString(aa);
    Console.WriteLine(s);
