    using System;
    using System.Text.RegularExpressions;
    public static string[] Tokenize(string equation)
    {
        Regex RE = new Regex(@"([\+\-\*\(\)\^\\])");
        return (RE.Split(equation));
    }
    //from here: https://www.safaribooksonline.com/library/view/c-cookbook/0596003390/ch08s07.html
