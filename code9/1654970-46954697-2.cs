    [XmlIgnore]
    public PointCollection Points { get; set; }
    [XmlElement("Points")]
    public string FakePoints
    {
        get { return string.Join(" ", Points.Select(p => p.X + "," + p.Y)); }
        set
        {
            var collection = new PointCollection();
            foreach (var s in value.Split())
            {
                var p = s.Split(',');
                collection.Add(new Point { X = int.Parse(p[0]), Y = int.Parse(p[1]) });
            }
            Points = collection;
        }
    }
