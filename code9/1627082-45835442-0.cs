    string[] names = new string[] { "Sangeen Khan", "Jhon", "Wasim", "Alexander", "Afridi" };
    string text = "I am Sangeen Khan and i am friend Jhon. Jhon is friend of Wasim.";
    foreach(string name in names)
    {
        text = text.Replace(name, "'Name'");
    }
    int matches = Regex.Matches(Regex.Escape(text), "'Name'").Count;
