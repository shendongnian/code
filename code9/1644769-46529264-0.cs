    List<string> arr=new List<string>();
    arr.Add("abc");
    arr.Add("def");
    arr.Add("ghi");
    string joined = string.Join(",", arr.Select(x => "MY" + x));
