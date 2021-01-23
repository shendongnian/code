	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SerialNumbers
	{
		private string[] itemsField;
		private ItemsChoiceType[] itemsElementNameField;
		[System.Xml.Serialization.XmlElementAttribute("Number", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}
	}
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType
	{
		Number,
		Type,
	}
