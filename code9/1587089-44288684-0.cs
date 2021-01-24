    class CheckBoxColumn : ITemplate
    {
        private CheckBox _checkbox;
        private event EventHandler checkedChanged;
        public event EventHandler CheckedChanged
        {
            add
            {
                if (_checkbox != null)
                {
                    checkedChanged += value;
                    _checkbox.CheckedChanged += value;
                }
            }
            remove
            {
                if (_checkbox != null)
                {
                    checkedChanged -= value;
                    _checkbox.CheckedChanged -= value;
                }
            }
        }
    
        public CheckBoxColumn()
        {
            _checkbox = new CheckBox();
            _checkbox.ID = "IDCheckBox";
            _checkbox.AutoPostBack = true;
        }
    
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (_checkbox != null) container.Controls.Add(_checkbox);
        }
    
        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            EventHandler handler = checkedChanged;
            if (handler != null) handler(this, e);
        }
    }
