    public frm_order()
        {
            
            InitializeComponent();
            
            AutoCompleteStringCollection farmerdatasource = new AutoCompleteStringCollection();
            for (int i = 0; i < farmer.GET_FARMER_NAME_HAVE_PRODUCT().Rows.Count;i++ ) {
                farmerdatasource.Add(farmer.GET_FARMER_NAME_HAVE_PRODUCT().Rows[i][1].ToString());
            }
            this.farmerNameCmb.AutoCompleteCustomSource = farmerdatasource;
            this.farmerNameCmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.farmerNameCmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                  
        }
