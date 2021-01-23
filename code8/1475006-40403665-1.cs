        public partial class ClassTwo
    {
      protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            {
                string filterText = ClassOne.MyNewString;
            }
        }
    }
