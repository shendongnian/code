c-sharp
using System;
using System.IO;
using Saxon.Api;
namespace Project1
{
    public static class ClassMain
    {
        public static string TransformXml(string xmlData, string xslData)
        {
            var xsltProcessor = new Processor();
            var documentBuilder = xsltProcessor.NewDocumentBuilder();
            documentBuilder.BaseUri = new Uri("file://");
            var xdmNode = documentBuilder.Build(new StringReader(xmlData));
            var xsltCompiler = xsltProcessor.NewXsltCompiler();
            var xsltExecutable = xsltCompiler.Compile(new StringReader(xslData));
            var xsltTransformer = xsltExecutable.Load();
            xsltTransformer.InitialContextNode = xdmNode;
            var results = new XdmDestination();
            xsltTransformer.Run(results);
            return results.XdmNode.OuterXml;
        }
        public static void Main()
        {
            var xmlData = File.ReadAllText("a.xml");
            var xslData = File.ReadAllText("a.xsl");
            var data = TransformXml(xmlData, xslData);
            Console.WriteLine(data);
            Console.ReadKey();
        }
    }
}
