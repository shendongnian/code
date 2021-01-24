    var s = "<Element><Element value=\"'hello&stack<overflow>'\" value=\"'hi&stack<over flow2 >'\"/></Element>";
    var rx = @"((?:<[a-zA-Z][\w:-]*|\G(?!\A))\s+[^\s=<]*=)(""[^""]*"")";
    var clean = Regex.Replace(s, rx, m => 
        string.Format("{0}{1}", m.Groups[1].Value, m.Groups[2].Value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;"))
    );
     // => <Element><Element value="'hello&amp;stack&lt;overflow&gt;'" value="'hi&amp;stack&lt;over flow2 &gt;'"/></Element>
