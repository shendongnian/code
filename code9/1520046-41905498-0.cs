    using System.Text.RegularExpressions;
    
    MatchCollection findings = new Regex(@"((.|(\n.))+)|((\n\n)((.|(\n.))+))").Matches(text);
    for(int i = 0; i < findings.Count; i++) {
        int groupIndex = findings[i].Groups[1].Length > 0 ? 0 : 6;
        string match = findings[i].Groups[groupIndex].ToString();
        Console.WriteLine(i+".");
        Console.WriteLine(match);
    }
