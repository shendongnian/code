    [XmlRoot("DEFTABLE")]
    public class DefTable
    {
        [XmlArrayItem("Cube")]
        public List<Cube> Cubes { get; set; }
    }
