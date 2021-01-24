    public class ExtendedDropDownList : System.Web.UI.WebControls.DropDownList
    {
        protected override void PerformDataBinding(IEnumerable dataSource)
        {
            try
            {
                base.PerformDataBinding(dataSource);
            }
            catch (ArgumentOutOfRangeException)
            {
                ListItem item;
                // try the value we defined as the one that represents <no selection>
                if (NoSelectionValue != null)
                {
                    item = Items.FindByValue(NoSelectionValue);
                    if (item != null)
                    {
                        item.Selected = true;
                        return;
                    }
                }
                // try the text we defined as the one that represents <no selection>
                if (NoSelectionText != null)
                {
                    item = Items.FindByText(NoSelectionText);
                    if (item != null)
                    {
                        item.Selected = true;
                        return;
                    }
                }
                // try the empty value if it exists
                item = Items.FindByValue(string.Empty);
                if (item != null)
                {
                    item.Selected = true;
                    return;
                }
            }
        }
        [DefaultValue(null)]
        public string NoSelectionValue
        {
            get
            {
                return (string)ViewState[nameof(NoSelectionValue)];
            }
            set
            {
                ViewState[nameof(NoSelectionValue)] = value;
            }
        }
        [DefaultValue(null)]
        public string NoSelectionText
        {
            get
            {
                return (string)ViewState[nameof(NoSelectionText)];
            }
            set
            {
                ViewState[nameof(NoSelectionText)] = value;
            }
        }
    }
}
