    private int SelectedRow;
    public int selectedRow
        {
            set
            {
                if(SelectedRow != value)
                {
                    SelectedRow = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRow"));
                    }
                }
            }
            get
            {
                return SelectedRow;
            }
        }
        private Object SelectedRowObject;
        public Object selectedRowObject
        {
            set
            {
                if (SelectedRowObject != value)
                {
                    SelectedRowObject = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRowObject"));
                        PropertyChanged(this, new PropertyChangedEventArgs("selectedRowDescription"));
                    }
                }
            }
            get
            {
                return SelectedRowObject;
            }
        }
        private String SelectedRowDescription;
        public String selectedRowDescription
        {
            get
            {
                if(SelectedRowObject != null && SelectedRowObject is Material)
                {
                    Material mat = (Material)SelectedRowObject;
                    return mat.description;
                } else
                {
                    return "-";
                }
            }
        }
