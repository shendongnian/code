    using System.Xml.Serialization;
    ...
    ...
    var points =  chart.Series[0].Points;
    
    List<SPoint> sPoints = points.Cast<DataPoint>()
                                 .Select(x => SPoint.FromDataPoint(x))
                                 .ToList();
    
    XmlSerializer xs = new XmlSerializer(sPoints.GetType());
    using (TextWriter tw = new StreamWriter(@"yourfilename.xml"))
    {
        xs.Serialize(tw, sPoints);
        tw.Close();
    }
