    void RegisterRoutes(RouteCollection routes)
    {
         routes.MapPageRoute("PrintRoute",
            "PrintProduct/{product}",
            "~/PrintProductInvoice.aspx");
    }
