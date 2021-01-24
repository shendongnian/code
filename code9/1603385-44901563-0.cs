            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(DateTime.UtcNow);
            }
            using (var streamReader = new StreamReader(filename))
            {
                string content = streamReader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(content);
            }
