    public static void Songlist(string fn)
    {
        filename = fn;
        foldername = filename + '/';
        pTWO = pONE + filename + ".txt";
    
        using (var reader = new System.IO.StreamReader(pTWO))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
    
                if (line.StartsWith("songlist "))
                {
                    var outputs = new List<string>();
                    
                    // compile all the outputs
                    var position = 9;
                    while (position <= line.Length)
                    {
                        string lister = line.Remove(0, position);
                        string output = lister.Split('"', '"')[1];
                        outputs.Add(output);
                        position += (2 + output.Length + 1);
                    }
    
                    // iterate over all the outputs
                    foreach (var output in outputs)
                    {
                        if (Directory.Exists("Content/musics/" + foldername) && output != null && File.Exists("Content/musics/" + foldername + output + ".mp3"))
                        {
                            media.controls.stop();
                            media.URL = "Content/musics/" + foldername + output + ".mp3";
                            media.controls.play();
    
                            Console.WriteLine("media.controls.currentPosition :: " + media.controls.currentPosition);
                            Console.WriteLine("media.currentMedia.duration    :: " + media.currentMedia.duration);
    
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                        }
                    }
                }
            }
    
            reader.Close();
        }
    }
