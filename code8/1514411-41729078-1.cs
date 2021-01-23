    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class Test
    {
    public static void Main()
    {
        string path = Directory.GetCurrentDirectory();
        string[] csfiles = Directory.GetFiles(path, "*.cs");
        foreach (var item in csfiles)
        {
            string text = File.ReadAllText(item, Encoding.Default);
            string newtext = text.Replace("‘", "\'")
                       .Replace("’", "\'")
                       .Replace("“", "\"")
                       .Replace("”", "\"");
            File.WriteAllText(item, newtext);
        }
    }
    }
