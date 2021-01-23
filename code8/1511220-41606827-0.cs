    public partial class ADD_PRODUCT_FORM : Form
    {
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
    
        public ADD_PRODUCT_FORM()
        {
            InitializeComponent();
            CMBIDCAT.DataSource = prd.GET_ID_CATEGORIES();
            CMBIDCAT.DisplayMember = "CAT_NAME";
            CMBIDCAT.ValueMember = "ID_CAT";
        }
    }
