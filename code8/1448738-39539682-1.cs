    [XmlRoot("monster")]
    public class monster
    {
        public flags flags { get; set; }
    }
    public class flags
    {
        const string SummonableName = "summonable"; // In c# 6.0 use nameof(summonable)
        const string AttackableName = "attackable"; // See  https://msdn.microsoft.com/en-us/library/dn986596.aspx
        [XmlIgnore]
        public int summonable { get; set; }
        [XmlIgnore]
        public int attackable { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlElement("flag")]
        public Flag[] Flags
        {
            get
            {
                return new[]
                {
                    new Flag { Name = SummonableName, Value = XmlConvert.ToString(summonable) },
                    new Flag { Name = AttackableName, Value = XmlConvert.ToString(attackable) },
                };
            }
            set
            {
                if (value == null)
                    return;
                foreach (var attr in value)
                {
                    if (attr.Name == SummonableName)
                        summonable = XmlConvert.ToInt32(attr.Value);
                    else if (attr.Name == AttackableName)
                        attackable = XmlConvert.ToInt32(attr.Value);
                }
            }
        }
    }
    public class Flag
    {
        [XmlIgnore]
        public string Name { get; set; }
        [XmlIgnore]
        public string Value { get; set; }
        [XmlAnyAttribute]
        public XmlAttribute[] XmlAttributes
        {
            get
            {
                var attr = new XmlDocument().CreateAttribute(Name.ToString());
                attr.Value = Value;
                return new [] { attr };
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    Name = null;
                    Value = null;
                }
                else if (value.Length == 1)
                {
                    Name = value[0].Name;
                    Value = value[0].Value;
                }
                else
                {
                    throw new ArgumentException("Too many attributes");
                }
            }
        }
    }
