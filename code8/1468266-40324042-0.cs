    using (var images = new MagickImageCollection())
    {
      var readSettings = new MagickReadSettings()
      {
        BackgroundColor = MagickColors.None, // -background none
        FillColor = MagickColors.Black, // -fill black
        Font = "Helvetica-Condensed-Light", // -font Helvetica-Condensed-Light
        FontPointsize = 26 // -pointsize 26
      };
    
      // label:'Foobar Controller 3.1.4.0 Installer'
      var image = new MagickImage("label:Foobar Controller 3.1.4.0 Installer", readSettings);
      image.RemoveAttribute("label"); // +set label
      images.Add(image);
    
      var montageSettings = new MontageSettings()
      {
        BackgroundColor = MagickColors.None, // -background none
        Shadow = true, // -shadow
        Geometry = new MagickGeometry(5, 5, 0, 0) // -geometry +5+5
      };
    
      using (MagickImage result = images.Montage(montageSettings))
      {
        result.Write("test_v3.png");
      }
    }
