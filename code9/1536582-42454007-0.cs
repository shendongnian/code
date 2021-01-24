    string _deskNumberXml;
    [JsonProperty(PropertyName = "u_additional_DeskNumber ")]
    public string DeskNumberXml 
    { 
       get { return _deskNumberXml; }
       set
       {
          _deskNumberXml = value;
          try
          {
             var xdoc = System.Xml.Linq.XDocument.Parse(value);
             var xelement = xdoc.Elements("AdditionalInfo").SelectMany(x => x.Elements("Number")).FirstOrDefault();
             DeskNumber = (xelement != null) ? xelement.Value : "";
          }
          catch
          {
             DeskNumber = "";
          }
       }
    }
    public string DeskNumber { get; set; }
