    public String Config { get; set; }
    
    public XElement xmlData
    {
        get { return XElement.Parse(Config); }
        set { Config = value.ToString(); }
    }
    
    public partial class XmlEntityMap : EntityTypeConfiguration<XmlEntity>
    {
        public FilterMap()
        {
            this.Property(c => c.Config).HasColumnType("xml");
            this.Ignore(c => c.xmlData);
        }
    }
