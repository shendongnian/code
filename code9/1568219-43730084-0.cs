    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    namespace AsyncPlinqExample
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Limit parallelism here if needed 
                int degreeOfParallelism = Environment.ProcessorCount;
                
                string resultDirectory = "[result directory path here]";
                string[] files = Directory.GetFiles("[directory with files here]");
                files.AsParallel()
                     .WithDegreeOfParallelism(degreeOfParallelism)
                     .Select(
                         async x =>
                         {
                             using (StreamReader reader = new StreamReader(x))
                             {
                                 XElement root = XElement.Parse(await reader.ReadToEndAsync());
                                 root.SetAttributeValue("filePath", Path.GetFileName(x));
                                 return root;
                             }
                         })
                     .Select(x => x.Result)
                     .Select(
                         x =>
                         {
                             // Perform other manipulations here
                             return x;
                         })
                     .Select(
                         async x =>
                         {
                             string resultPath = 
                                 Path.Combine(
                                     resultDirectory,
                                     (string) x.Attribute("fileName"));
                             await Console.Out.WriteLineAsync($"{DateTime.Now}: Starting {(string) x.Attribute("fileName")}.");
                             using (StreamWriter writer = new StreamWriter(resultPath))
                             {
                                 await writer.WriteAsync(x.ToString());
                             }
                             await Console.Out.WriteLineAsync($"{DateTime.Now}: Comleted {(string)x.Attribute("fileName")}.");
                         });
            }
        }
    }
