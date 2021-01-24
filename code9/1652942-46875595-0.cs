    <%@ Page Language="C#"  %>
    <%
        Response.Write("hello from NET " + System.Environment.Version.ToString() +"<br>");
    
        Response.Write("<br>HttpContext.Current.Server.MapPath:<br>" + HttpContext.Current.Server.MapPath("/")); // physical root of application
        Response.Write("<br>HttpRuntime.AppDomainAppPath:<br>" + HttpRuntime.AppDomainAppPath); // The filesystem folder containing your application
        Response.Write("<br>HttpRuntime.AppDomainAppVirtualPath:<br>" + HttpRuntime.AppDomainAppVirtualPath); //
        Response.Write("<br>Request.ApplicationPath :</strong><br>" + Request.ApplicationPath); // Gets the IIS root virtual path for your ASP.net application. ASP.NET transforms ~/ into this value when making an absolute virtual path.
    %>
