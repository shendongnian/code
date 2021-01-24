    public class SimpleHttpModule : IHttpModule 
    { 
      public SimpleHttpModule(){} 
      public String ModuleName 
      { 
        get { return "SimpleHttpModule"; } 
      } 
      public void Init(HttpApplication application) 
      { 
        application.BeginRequest +=  
        (new EventHandler(this.Application_BeginRequest)); 
        application.EndRequest +=  
        (new EventHandler(this.Application_EndRequest)); 
      } 
      private void Application_BeginRequest(Object source,  
      EventArgs e) 
      { 
        HttpApplication application = (HttpApplication)source; 
        HttpContext context = application.Context; 
        context.Response.Write(SomeHtmlString); 
      } 
      private void Application_EndRequest(Object source, EventArgs e) 
      { 
        HttpApplication application =      (HttpApplication)source; 
        HttpContext context = application.Context; 
        context.Response.Write(SomeHtmlString); 
      } 
      public void Dispose(){} 
    } 
    <configuration> 
      <system.web> 
        <httpModules> 
          <add name=" SimpleHttpModule " type=" SimpleHttpModule "/> 
        </httpModules> 
      </system.web> 
    </configuration> 
