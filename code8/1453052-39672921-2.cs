    string s ="12-15";
    string[] words = s.Split('-');
    foreach (string word in words)
    {
        int convertedvalue = Convert.ToInt32(word ); 
        Console.WriteLine(word);
    }
    string[] ss= s.Split('-');
    int x = Convert.ToInt32(ss[0]);
    int y = Convert.ToInt32(ss[1]);
