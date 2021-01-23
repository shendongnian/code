        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("",
                  "a-page", "~/index.aspx?qs=a-page");
        }
