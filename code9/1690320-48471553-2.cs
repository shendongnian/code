    public static class XmlNamespaces
    {
        public const string OpengisWfs = "http://www.opengis.net/wfs";
    }
    [XmlRoot(Namespace = XmlNamespaces.OpengisWfs)]
    public class Query
    {
        public Filter Filter { get; set; }
    }
    [XmlInclude(typeof(PropertyIsOpFilter))]
    [XmlInclude(typeof(OpFilterBase))]
    [XmlRoot(Namespace = XmlNamespaces.OpengisWfs)]
    public class Filter
    {
        [XmlElement]
        public Filter And { get; set; }
    }
    [XmlInclude(typeof(PropertyIsEqualToFilter))]
    [XmlRoot(Namespace = XmlNamespaces.OpengisWfs)]
    public class PropertyIsOpFilter : Filter
    {
        public Filter LeftOp { get; set; }
        public Filter RightOp { get; set; }
    }
    [XmlRoot("IsEqualTo", Namespace = XmlNamespaces.OpengisWfs)]
    public class PropertyIsEqualToFilter : PropertyIsOpFilter { }
    [XmlInclude(typeof(LiteralFilter))]
    [XmlRoot(Namespace = XmlNamespaces.OpengisWfs)]
    public class OpFilterBase : Filter
    {
        public string Op { get; set; }
        public object Value { get; set; }
    }
    [XmlRoot(Namespace = XmlNamespaces.OpengisWfs)]
    public class LiteralFilter : OpFilterBase { }
