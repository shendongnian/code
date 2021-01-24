    string a = "Today is a nice day, and I have been driving";
    var res = a.Split();
    List<string> groups = new List<string>();
    for(int i=0;i< res.Length;i+=3)
    {
        string result = string.Empty;
        try
        {
            result += res[i];
        }
        catch(Exception)
        {
            break;
        }
        try
        {
            result +=" "+ res[i+1];
        }
        catch (Exception)
        {
            groups.Add(result);
            break;
        }
        try
        {
            result +=" "+ res[i+2];
        }
        catch (Exception)
        {
            groups.Add(result);
            break;
        }
        groups.Add(result);
    }
    foreach(var a1 in groups)
    {
        Console.WriteLine(a1);
    }
