            public string UrlPortal { get { return System.Configuration.ConfigurationManager.AppSettings["Portal"].ToString(); } }
    
            public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext filterContext)
            {    
                try
                {                 
                    if (StateManager.Instance.Get(Key.Autenticacao, State.Session) == null)
                    {                        
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
                        filterContext.Response.Headers.Location = new Uri(http://www.examplepage.com);
                        /*add this return*/return;
                    }
    
                    base.OnActionExecuting(filterContext);
                }
                catch (Exception ex)
                {    
                    throw;
                }
            }
        }
