        [IgnoreDataMember, XmlIgnore]
        public bool BoolProp  { get; set; }
        /// <summary>
        ///     XML serialized BoolProp 
        /// </summary>
        [DataMember(Name = "BoolProp"]
        [XmlElement(ElementName = "BoolProp"]
        public int FormattedBoolProp 
        {
            get { 
				return BoolProp ? 1 : 0;
			}
            set { BoolProp = value==1 }
        }
