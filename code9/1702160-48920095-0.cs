    using System;
    using System.Linq;
    using System.Xml.Linq;
    namespace ParsingXML
    {
        class Program
        {
            const string _xml =
                @"<Asset>
                  <Id>urn:uuid:d0686356-19c7-4bf4-b915-db778c308d1c</Id>
                  <ChunkList>
                    <Chunk>
                      <Path>CPL_IMF_JOT_Sample.xml</Path>
                      <VolumeIndex>1</VolumeIndex>
                      <Offset>0</Offset>
                      <Length>21881</Length>
                    </Chunk>
                  </ChunkList>
                </Asset>";
            static void Main(string[] args)
            {
                ReplacePath(
                    @"urn:uuid:d0686356-19c7-4bf4-b915-db778c308d1c",
                    @"c:\path\to\somefilename.xml"
                    );
                Console.WriteLine("Enter to exit...");
                Console.ReadLine();
            }
            static void ReplacePath(string id, string pathToSet)
            {
                XDocument document = XDocument.Parse(_xml);
                var assetElements = document.Elements("Asset");
                foreach (var asset in assetElements)
                {
                    var innerElements = asset.Elements("Id");
                    var matchingId = innerElements.FirstOrDefault(e => e.Value.Equals(id));
                    if (matchingId == null)
                    {
                        Console.WriteLine("id not found");
                        return;
                    }
                    var chunks = asset.Elements("ChunkList").First().Elements();
                    foreach (var chunk in chunks)
                    {
                        chunk.Elements("Path").First().SetValue(pathToSet);
                    }
                }
                var xml = document.ToString();
                Console.WriteLine(xml);
                Console.WriteLine("Enter to exit...");
                Console.ReadLine();
            }
        }
    }
