    var list1 = new List<string> { "email1", "email2" };
    string[] list2 = { "*@gmail.com", "bob@*.com", "tony??@*.com" };
    var pattern = "^(" + Regex.Escape(string.Join("|", list2)).Replace("\\|", "|").Replace("\\?", ".?").Replace("\\*", ".*") + ")$"; 
    var regEx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    list1.RemoveAll(regEx.IsMatch);
