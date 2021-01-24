            string html = "<body>Text to read </body>";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            Regex regx = new Regex("<body>(?<theBody>.*)</body>", options);
            Match match = regx.Match(html);
            if (match.Success)
            {
                string theBody = match.Groups["theBody"].Value;
                //Here I'm getting all the data present in body tag              
            }
