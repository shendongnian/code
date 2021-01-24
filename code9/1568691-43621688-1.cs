    public partial class YourControl : System.Web.UI.UserControl
    {
        private ControlState _controlState;
        public ControlState State { get { return _controlState; } }
        protected void Page_Load(object source, EventArgs e)
        {
            _controlState= ViewState["controlState"] as ControlState ?? new ControlState();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["controlState"] = _controlState;
        }
