    [DataContract]
    [KnownType(typeof(Label))]
    public abstract class DrawingObject
    {
    public abstract string Location { get; set; }
    public abstract string Size { get; set; }
    }
