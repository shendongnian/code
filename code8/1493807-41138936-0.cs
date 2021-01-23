     var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        var path = Path.Combine(dir, "Resources", "parser.py");
        string script;
        using (var sr = new StreamReader(path))
        {
            script = sr.ReadToEnd();
        }
        path = Path.Combine(root, "parser.pyw");
        using (var fw = new StreamWriter(path))
        {
            fw.Write(script);
        }
