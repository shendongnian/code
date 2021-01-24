    [DataContract]
    public class operation_unitaire : ISerializable
    {
        [XmlElement(ElementName = "categorie_operation", Order = 1, IsNullable = false, Type = typeof(string))]
        [DataMember(Name = "categorie_operation", Order = 1, IsRequired = true)]
        public string categorie_operation { get; set; }
