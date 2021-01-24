    public partial class Pages_GuitarItems1 : System.Web.UI.Page
    {
        public List<guitarItem> guitarItemList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          var brand = this.Request.QueryString["brand"];
          guitarItemList = new List<guitarItem>();
          guitarItemList = ConnectionClassGuitarItems.GetGuitarItems(brand);
        }
    }
