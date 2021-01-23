    	string[] numbers ={	"/Gender=&Age=&Query=&Orgrimmar+l%C3%A4n=01&Stormwind+l%C3%A4n=07&Undercity+l%C3%A4n=09&Pag"};
    string sPattern = @"(?<=&Orgrimmar)+";
    string sPattern2 = @"(?<=&Stormwind)+";
    foreach (string s in numbers){
    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern) && System.Text.RegularExpressions.Regex.IsMatch(s, sPattern2))
...
