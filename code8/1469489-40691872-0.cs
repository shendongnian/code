    using (MagickImage image = new MagickImage("wizard:"))
    {
      image.Write(@"c:\test.jpg", new JpegWriteDefines()
      {
        SamplingFactors = new MagickGeometry[]
        {
          new MagickGeometry ("2x2"),
          new MagickGeometry ("1x1"),
          new MagickGeometry ("1x1")
        },
        QuantizationTables = @"c:\YourQuantizationTables.xml"
      });
    }
