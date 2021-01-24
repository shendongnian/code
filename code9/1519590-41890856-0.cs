    Dictionary<Tuple<int, int>, bool> _sessionDict;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || !(Session["SessionsampleDict"] is Dictionary<Tuple<int, int>, bool>))
        {
            Dictionary<Tuple<int, int>, bool> localDict = new Dictionary<Tuple<int, int>, bool>();
            Session["SessionsampleDict"] = localDict;
        }
        _sessionDict = (Dictionary<Tuple<int, int>, bool>)Session["SessionsampleDict"];
    }
