    string str = "({a,b,c,d},{(a,b),(b,c),(a,c),(c,d)})";
    string group1 = new Regex(@"([a-z](\,[a-z])*)+").Match(str).Value;
    string group2 = new Regex(@"(\(([a-z],?)*\),?)+").Match(str).Value;
    string[] arr1 = group1.Split(',');
    string[] arr2 = group2.Split(new[] { "),(" }, StringSplitOptions.None)
        .Select(s => Regex.Replace(s, @"[^a-z]+", String.Empty)).ToArray();
