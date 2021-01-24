    using System.Text.RegularExpressions;
    
    string Arrival = Request.QueryString["Arrival"]; // 13.11.2017
    string dateString = Regex.Replace(Arrival, @"\.", "/"); // 13/11/2017
    DateTime date = DateTime.ParseExact(dateString , "dd/MM/yyyy", null); // 11/13/2017 00:00:00
