    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    namespace ConsoleApplication2
    {
    class Program
    {
    static void Main(string[] args)
        {
    var path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "XMLFile1.xml");
            LoadTMX(path);
     }
        public static void LoadTMX( string path)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    List<int> gids = new List<int>();
    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(stream);
    int width = int.Parse(xdoc.DocumentElement.GetAttribute("width"));
    int height = int.Parse(xdoc.DocumentElement.GetAttribute("height"));
    int tileWidth = int.Parse(xdoc.DocumentElement.GetAttribute("tilewidth"));
    int tileHeight = int.Parse(xdoc.DocumentElement.GetAttribute("tileheight"));
    XmlNodeList layers = xdoc.DocumentElement.SelectNodes("layer");
    for (int i = 0; i < layers.Count; i++)
                    {
                        XmlNodeList tiles = layers[i].SelectSingleNode("data").SelectNodes("tile");
    Console.WriteLine(tiles.Count);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    }
