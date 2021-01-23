    public class Account
    {
        public Account() { this.AccountNodes = new List<AccountNode>(); }
        [XmlIgnore]
        public List<AccountNode> AccountNodes { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAnyElement]
        public XElement[] AccountNodesXml
        {
            get
            {
                if (AccountNodes == null)
                    return null;
                return AccountNodes.Select(a => new XElement((XName)a.Name, a.Value)).ToArray();
            }
            set
            {
                if (value != null)
                    AccountNodes = value.Select(e => new AccountNode { Name = e.Name.LocalName, Value = (string)e }).ToList();
            }
        }
    }
