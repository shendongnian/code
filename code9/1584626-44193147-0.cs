    public override void RegisterArea(AreaRegistrationContext context) 
    {
       context.MapRoute(
          "Display_default",
          "Display/{controller}/{action}/{id}/{id2}/{id3}/{id4}/{id5}/{*id6}",
           new { action = "Index", id = UrlParameter.Optional , id2 = UrlParameter.Optional, id3 = UrlParameter.Optional }
       );
    }
