    static void Main(string[] args)
            {
                string url = "http://tfscollectionurl/";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(url));
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                Item item = vcs.GetItem("$/Path/of/file");
                var filestream = item.DownloadFile();
                string content;
                using (var memoryStream = new MemoryStream())
                {
                    filestream.CopyTo(memoryStream); // Throws  DownloadTicketValidationException:TF15006: The request file ID was missing or empty.
                    using (var streamReader = new StreamReader(new MemoryStream(memoryStream.ToArray())))
                    {
                        content = streamReader.ReadToEnd();
                    }
                }
                Console.WriteLine(content);
                Console.ReadLine();
            }
