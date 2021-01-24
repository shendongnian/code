    public class PlayerRow
    {
        public PlayerRow(string aName, string aValue)
        {
            AttribsPlayerLine = new List<AttribLine>();
            AttribLine temp = new AttribLine();
            temp.attribName = aName;
            temp.attribValue = aValue;
            AttribsPlayerLine.Add(temp);
        }
        public List<AttribLine> AttribsPlayerLine { get; set; }
    
        public class AttribLine
        {
    
        [Description("AttribName")]
        public string attribName { get; set; }
    
        [Description("AttribValue")]
        public string attribValue { get; set; }
        }
    }
