    private void convert()
    {
        Parallel.ForEach(source.GetFiles("*.tif"), 
             new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, 
             file =>
             {                  
                fileName = file.Name;
                using (MagickImage image = new MagickImage(sourceFolderPath + "\\" + file))
                {
                    image.ColorSpace = ColorSpace.XYZ;
                    image.GammaCorrect(2.4);
                    image.Write(destinationFolderPath + "\\" + fileName);
                }
             });
    }
