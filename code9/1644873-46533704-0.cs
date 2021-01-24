    public class DetailAmounts
    {
        [XmlAttribute]
        public DateTime Date { get; set; }
        [XmlAttribute]
        public string Amounts { get; set; }
    }
    // ...
    var xml = "<DetailAmounts Date=\"2014-01-01\" Amounts=\"100717.72 100717.72 100717.72 100717.72\" />";
    var serializer = new XmlSerializer(typeof(DetailAmounts));
    using (var reader = new StringReader(xml))
    {
        var detailAmounts = (DetailAmounts)serializer.Deserialize(reader);
    }
