            var fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var reader = new StreamReader(fs);
            await Task.Delay(500);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
 
