    [XmlAttribute(AttributeName = "Pages")]
    public string PagesString { get; set; }
    public IList<int> Pages {
        get {
            return PagesString.Split(',').Select(x => Convert.ToInt32(x.Trim())).ToList();
        }
        set {
           PagesString = String.Join(",", value);
        }
    }
