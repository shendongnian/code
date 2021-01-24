    string r = "\r";
    string n = "\n";
    string CarriageReturn = (Convert.ToChar(13)).ToString();
    string LineFeed = (Convert.ToChar(10)).ToString();
    
    var content = new string[] {
        $"(r:{r})", 
        $"(n:{n})", 
        $"(13:{CarriageReturn})", 
        $"(10:{LineFeed})" 
    };
    System.IO.File.WriteAllLines("output1.txt", content);
    System.IO.File.WriteAllText("output2.txt", string.Join("", content));
