      static void Main(string[] args)
        {
            using (var engine = new Engine())
            {
                string file = @"C:\Users\wilso\Downloads\IZA - Meu Talismã.mp4";
                var inputFile = new MediaFile { Filename = file };
                engine.GetMetadata(inputFile);
                var outputName = @"C:\Users\wilso\Downloads\output";
                var outputExtension = ".mp4";
                double Duration = inputFile.Metadata.Duration.TotalSeconds;
                double currentPosition = 0;
                int contador = 0;
                while (currentPosition < Duration)
                {
                    currentPosition = contador * 30;
                    contador++;
                    var options = new ConversionOptions();
                    var outputFile = new MediaFile(outputName + contador.ToString("00") + outputExtension);
                    options.CutMedia(TimeSpan.FromSeconds(currentPosition), TimeSpan.FromSeconds(30));
                    engine.Convert(inputFile, outputFile, options);
                }
            }
        }
