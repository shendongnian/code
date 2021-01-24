    var regex = new Regex(@"[^\u0000-\u007F]+", RegexOptions.Compiled);
    using (var sr = new StreamReader(pth_input))
    {
        using (var x = new StreamWriter(pth_output))
        {
            while ((lx = sr.ReadLine()) != null)
            {
                var text = sr.ReadToEnd();
                var result = regex.Replace(text, String.Empty);
                x.Write(result);
            }
        }
    }
