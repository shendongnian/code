    public struct TreatmentZone
    {
    #region members
    private readonly GraphicsPath path;
    #endregion
    //changed to properties
    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Description { get; private set; }
    public Color Color { get; set; } 
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public TreatmentZone(int zoneId, string zoneCode, string description, Color color, int x, int y, int width, int height)
    {
      this.Id = zoneId;
      this.Code = zoneCode;
      this.Description = description;
      this.Color = color;
      this.X = x;
      this.Y = y;
      this.Width = width;
      this.Height = height;
      this.path = new GraphicsPath();
      //needed for hittest
      this.path.AddEllipse(this.X, this.Y, this.Width, this.Height);
    }
    //https://stackoverflow.com/questions/13285007/how-to-determine-if-a-point-is-within-an-ellipse
    //This will check if the point (from mouse) is over ellips or not
    public bool HitTest(Point point)
    {
      var x = point.X - this.X;
      var y = point.Y - this.Y;
      return this.path.IsVisible(x, y);
    }
