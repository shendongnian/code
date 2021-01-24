    using System.Text.RegularExpressions;
    string query = "Free Chips (Save $43 / month)";
    
    // ...
    
    Regex r = new Regex(@".*?(?=\s*\(Save)");
    
    Match m = r.Match(query);
    if(m.Success) {
        string result = m.ToString(); // result = "Free Chips"
    }
