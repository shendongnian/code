    List<string> list = new List<string>();
    list.Add("Hi");
    list.Add("Its me!");
    string s = String.Join(" ", list.Select(x => (list.IndexOf(x) + 1).ToString() + ")" + x));
    Console.WriteLine(s);
