    [Serializable()]
    public class DeactivationsGroup
    {
        public DeactivationsGroup() { this.GroupNames = new Dictionary<string, GroupName>(); }
        [XmlIgnore]
        public Dictionary<string, GroupName> GroupNames { get; set; }
        public int Level { get; set; }
        [XmlAttribute]
        public byte index { get; set; }
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement[] XmlGroupNames
        {
            get
            {
                return GroupNames.SerializeToXElements(null);
            }
            set
            {
                if (value == null || value.Length < 1)
                    return;
                foreach (var pair in value.DeserializeFromXElements<GroupName>())
                {
                    GroupNames.Add(pair.Key, pair.Value);
                }
            }
        }
    }
