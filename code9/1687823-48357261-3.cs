        static void MeasureSaxon(string xmlUrl, string xslUrl, string outputFile)
        {
            Processor processor = new Processor();
            Xslt30Transformer xslt30Transformer = processor.NewXsltCompiler().Compile(new Uri(xslUrl)).Load30();
            Stopwatch watch = new Stopwatch();
            using (Stream resultStream = File.OpenWrite(outputFile))
            {
                using (Stream inputStream = File.OpenRead(xmlUrl))
                {            
                    watch.Start();
                    xslt30Transformer.ApplyTemplates(inputStream, processor.NewSerializer(resultStream));
                    watch.Stop();
                }
            }
            Console.WriteLine("{0} ms", watch.ElapsedMilliseconds);
        }
