    var points = new List<Point>();
            
    lines.Map(line =>
    {
         points.Add(line.startPoint);
         points.Add(line.EndPoint);
     } );
