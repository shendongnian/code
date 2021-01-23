		[XmlIgnore]
        public List<Field> InstanceFields { get; set; }
        [XmlArray("Instance")]
        [XmlArrayItem("Field")]
		public Field [] InstanceFieldsArray
		{
			get
			{
				if (InstanceFields == null)
					return null;
				return InstanceFields.ToArray();
			}
			set
			{
				(InstanceFields = InstanceFields ?? new List<Field>()).Clear();
				InstanceFields.AddRange(value ?? Enumerable.Empty<Field>());
			}
		}
    Sample [fixed fiddle](https://dotnetfiddle.net/hToEJC).
