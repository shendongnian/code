    using System.Text.RegularExpressions;
    var regex = new Regex(@"[A-Za-z]");  // You have many options here
    if (regex.IsMatch(str))
    {
        //Some codes
    }
