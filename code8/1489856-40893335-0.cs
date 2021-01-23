    using System;
    using System.IO;
    using System.IO.Packaging;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;
    internal class Program
    {
        private static readonly XNamespace dcterms = "http://purl.org/dc/terms/";
        private static void Main(string[] args)
        {
            var fileName = args[0];
            // open the ZIP package
            var package = Package.Open(fileName);
            // convert the package to a single XML document
            var xdoc = OpcToFlatOpc(package);
            // remove the nodes we are not interested in
            // here you can add other nodes as well
            xdoc.Descendants(dcterms + "modified").Remove();
            // get a stream of the XML and compute the hash
            using (var ms = new MemoryStream())
            {
                xdoc.Save(ms);
                ms.Position = 0;
                string md5 = GetHash(ms);
                Console.WriteLine(md5);
            }
        }
        private static string GetHash(Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(stream);
                var bob = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    bob.Append(data[i].ToString("X2"));
                }
                return bob.ToString();
            }
        }
        private static XDocument OpcToFlatOpc(Package package)
        {
            XNamespace pkg = "http://schemas.microsoft.com/office/2006/xmlPackage";
            var declaration = new XDeclaration("1.0", "UTF-8", "yes");
            var doc = new XDocument(
                declaration,
                new XProcessingInstruction("mso-application", "progid=\"Word.Document\""),
                new XElement(
                    pkg + "package",
                    new XAttribute(XNamespace.Xmlns + "pkg", pkg.ToString()),
                    package.GetParts().Select(GetContentsAsXml)));
            return doc;
        }
        private static XElement GetContentsAsXml(PackagePart part)
        {
            XNamespace pkg = "http://schemas.microsoft.com/office/2006/xmlPackage";
            if (part.ContentType.EndsWith("xml"))
            {
                using (var partstream = part.GetStream())
                {
                    using (var streamReader = new StreamReader(partstream))
                    {
                        string streamString = streamReader.ReadToEnd();
                        if (!string.IsNullOrEmpty(streamString))
                        {
                          var newXElement =
                            new XElement(
                              pkg + "part",
                              new XAttribute(pkg + "name", part.Uri),
                              new XAttribute(pkg + "contentType", part.ContentType),
                              new XElement(pkg 
                                + "xmlData", XElement.Parse(streamString)));
                            return newXElement;
                        }
                        return null;
                    }
                }
            }
            using (var str = part.GetStream())
            {
                using (var binaryReader = new BinaryReader(str))
                {
                    int len = (int)binaryReader.BaseStream.Length;
                    var byteArray = binaryReader.ReadBytes(len);
                    // the following expression creates the base64String, then chunks
                    // it to lines of 76 characters long
                    string base64String = Convert.ToBase64String(byteArray)
                           .Select((c, i) => new { Character = c, Chunk = i / 76 })
                           .GroupBy(c => c.Chunk)
                           .Aggregate(
                               new StringBuilder(),
                               (s, i) =>
                                   s.Append(
                                       i.Aggregate(
                                           new StringBuilder(),
                                           (seed, it) => seed.Append(it.Character),
                                           sb => sb.ToString()))
                                    .Append(Environment.NewLine),
                               s => s.ToString());
                    return new XElement(
                        pkg + "part",
                        new XAttribute(pkg + "name", part.Uri),
                        new XAttribute(pkg + "contentType", part.ContentType),
                        new XAttribute(pkg + "compression", "store"),
                        new XElement(pkg + "binaryData", base64String));
                }
            }
        }
    }
