    string s1 = "<p>Hello world, hello world</p>";
    string[] terms = new string[] {"hello", "world"};
    var match = 1;
    s1 = Regex.Replace(s1,
    	    String.Join("|", String.Join("|", terms.OrderByDescending(s => s.Length)
    	        .Select(Regex.Escape))),
        m => String.Format("<span id=\"m_{0}\">{1}</span>", match++, m.Value),
        RegexOptions.IgnoreCase);
   	Console.Write(s1);
    // => <p><span id="m_1">Hello</span> <span id="m_2">world</span>, <span id="m_3">hello</span> <span id="m_4">world</span></p>
