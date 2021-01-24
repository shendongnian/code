    <system.web>  
        <customErrors mode="On" defaultRedirect="~/Error/DefaultError">
    </system.web>
          
    // ErrorController ActionResult method...
    public ActionResult DefaultError()
    {
     return view();
    }
