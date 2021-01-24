                using (var client = new WebClient())
            {
                client.DownloadFile("www.website.com/file.txt", "files/file.txt");
            }
            string[] fileContent = File.ReadAllLines("files/file.txt");
            while (true)
            {
                try
                {
                    if (File.Exists("files/file.txt")) File.Delete("files/file.txt");
                    break;
                }
                catch (IOException)
                {
                    codeTrue = true;
                }
            }
