    var fileStream = new FileStream(Directory.GetCurrentDirectory() + @"\DvDB.ADB", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains(""+Model_Number))
                    {
                       var arr = line.split(' ');
                       Array.Resize(ref arr, 4);
                       string 4words = string.Join(" ", arr);
                    }
                }
            }
