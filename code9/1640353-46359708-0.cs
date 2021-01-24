	[XmlRoot("HomePageItemList")]
    public class TestSerialization
    {
       [XmlElement("PlantHomePageItem", Type = typeof(PlantHomePageItem))]
       [XmlElement("AdminHomePageItem", Type = typeof(AdminHomePageItem))]
       public List<HomePageItem> HomePageItemList { get; set; }
    }
