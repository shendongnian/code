    public class DataMappingViewModel
    {          
        public string TableName { get; set; }
        public List<XmlElementViewModel> XmlElements { get; set; }
        public IEnumerable<string> ColumnList { get; set; } // for generating the SelectLists
    }
    public class XmlElementViewModel
    {
        public string ElementName { get; set; }
        public string SelectedColumn { get; set; } // to bind the selected value to
    }
