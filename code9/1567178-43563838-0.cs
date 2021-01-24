    string input = "3 Speed internal gear with 55 coaster";
    string pattern = @"\B[a-z]+|\W+";
    string replacement = "";
    Regex rgx = new Regex(pattern);
    string result = rgx.Replace(input, replacement);
