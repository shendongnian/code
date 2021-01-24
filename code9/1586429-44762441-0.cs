    public class DataGridViewAutoCompleteColumn : DataGridViewColumn
    {
        public DataGridViewAutoCompleteColumn()
            : base(new DataGridViewAutoCompleteCell())
        {
        }
    
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a DataGridViewAutoCompleteCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewAutoCompleteCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewAutoCompleteCell");
                }
                base.CellTemplate = value;
            }
        }
    
        [Browsable(true)]
        public List<string> AutoCompleteList
        {
            get; set;
        }
    
        [Browsable(true)]
        public int MinTypedCharacters { get; set; }
        [Browsable(true)]
        public bool CaseSensitive { get; set; }
    
        public override object Clone()
        {
            DataGridViewAutoCompleteColumn clone = (DataGridViewAutoCompleteColumn)base.Clone();
            clone.AutoCompleteList = this.AutoCompleteList;
            clone.MinTypedCharacters = this.MinTypedCharacters;
            clone.CaseSensitive = this.CaseSensitive;
            return clone;
        }
    }
