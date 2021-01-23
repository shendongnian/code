    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using System.IO;
     
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string teamProjectCollectionUrl = "http://YourTfsUrl:8080/tfs/YourTeamProjectCollection";
                string filePath = @"C:\project\myfile.cs";
     
                // Get the version control server
                TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(teamProjectCollectionUrl));
                VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
     
                // Get the latest Item for filePath
                Item item = versionControlServer.GetItem(filePath, VersionSpec.Latest);
     
                // Download and display content to console
                string fileString = string.Empty;
     
                using (Stream stream = item.DownloadFile())
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        
                        // Use StreamReader to read MemoryStream created from byte array
                        using (StreamReader streamReader = new StreamReader(new MemoryStream(memoryStream.ToArray())))
                        {
                            fileString = streamReader.ReadToEnd();
                        }
                    }
                }
     
                Console.WriteLine(fileString);
                Console.ReadLine();
            }
        }
    }
