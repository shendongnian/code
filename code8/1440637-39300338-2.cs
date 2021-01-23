    var svg = new SvgDocument();
    var colorServer = new SvgColourServer(System.Drawing.Color.Black);
     
    var group = new SvgGroup {Fill = colorServer, Stroke = colorServer};
    svg.Children.Add(group);
      foreach (var stroke in InkCanvas.Strokes)
      {
          var geometry = stroke.GetGeometry(stroke.DrawingAttributes).GetOutlinedPath‌​Geometry();
          var s = XamlWriter.Save(geometry);
        
          if (s.IsNotNullOrEmpty())
          {
              var element = XElement.Parse(s);
        
              var data = element.Attribute("Figures")?.Value;
        
              if (data.IsNotNullOrEmpty())
              {
                  group.Children.Add(new SvgPath
                  {
                      PathData = SvgPathBuilder.Parse(data),
                      Fill = colorServer,
                      Stroke = colorServer
                   });
               }
           }
    }
