        static void ReplacePath(string targetFile, string id, string outfile)
        {
            //XDocument document = XDocument.Parse(_xml);
            XDocument document = XDocument.Load(targetFile);
            // get root namespace to use with rest of element names
            var ns = document.Root.GetDefaultNamespace();
            var assetMap = document.Elements(ns + "AssetMap").First(); // this ignores the namespace
            var assetList = assetMap.Elements(ns + "AssetList").First();
            var assetElements = assetList.Elements(ns + "Asset");
            foreach (var asset in assetElements)
            {
                var innerElements = asset.Elements(ns + "Id");
                var matchingId = innerElements.FirstOrDefault(e => e.Value.Equals(id));
                if (matchingId == null)
                {
                    continue;
                }
                var chunks = asset.Elements(ns + "ChunkList").First().Elements();
                foreach (var chunk in chunks)
                {
                    var chunkElement = chunk.Elements(ns + "Path").First();
                    chunkElement.SetValue(outfile);
                }
            }
            var xml = document.ToString();
            Console.WriteLine(xml);
            Console.WriteLine("writing to file");
            document.Save(targetFile);
            Console.WriteLine("Enter to exit...");
            Console.ReadLine();
        }
