         IClientContext _clientContext;
        #region Constructors
        public HomeController()
        {
            // Called by MVC
        }
        public HomeController(IClientContext clientContext)
        {
            _clientContext = clientContext;
        }
        #endregion
        [SharePointContextFilter]
        public ActionResult Index()
        {
            if (_clientContext == null)
            {
                var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
                _clientContext = new ClientContextAdapter(spContext.CreateUserClientContextForSPHost());
            }
            if (_clientContext != null)
            {
                User spUser = _clientContext.Web.CurrentUser;
                _clientContext.Load(spUser, user => user.Title);
                _clientContext.ExecuteQuery();
                ViewBag.UserName = spUser.Title;
            }
            return View();
        }
