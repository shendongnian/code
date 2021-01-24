    string a = "Today is a nice day, and I have been driving";
    var res = a.Split();
    List<string> groups = new List<string>();
    Regex rgx = new Regex("[^a-zA-Z0-9]");
    for (int i=0;i< res.Length;i+=3)
    {
        string result = string.Empty;
        try
        {
            result += rgx.Replace(res[i], ""); 
        }
        catch(Exception)
        {
    
        }
        try
        {
            result +=" "+ rgx.Replace(res[i+1], ""); ;
        }
        catch (Exception)
        {
            groups.Add(result);
            break;
        }
        try
        {
            result +=" "+ rgx.Replace(res[i + 2], ""); 
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
    
    for (int i = 0; i < res.Length; i+=3)
    {
        Console.WriteLine(res.Skip(i).Take(3).Aggregate((current, next) => current + " " + next));
    }
