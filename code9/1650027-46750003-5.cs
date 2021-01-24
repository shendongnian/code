    public async void Imagesaver(string url)
    {
            
        string result = Filename(url);
        string SourceCode = worker.GetSourceCode(url);
        List<string> names1 = new List<string>();
        MatchCollection data2 = Regex.Matches(SourceCode, "(src=\"|src=\\/\")([^>]*?jpg|png|gif)", RegexOptions.Singleline);
        string name = string.Empty;
            foreach (Match m in data2)
            {
                name = m.Groups[2].Value;
                if (name.Contains("http"))
                {
                    names1.Add(name);
                }
                else
                {
                    names1.Add(url+name);
                }
            }
        
            int i = 0;
            WebClient client = new WebClient();
            foreach (string name2 in names1)
            {
                
                Uri imageurl = new Uri(name2);
                try
                {
                    
                  await  Task.Run(()=>client.DownloadFileAsync(imageurl, (@"C:\Users\Ramazan BIYIK\Desktop\HTML içerik\" + result+"\\" + i + ".jpg")));
                    i++;
                }
                catch(Exception ex) {continue; }
            }
