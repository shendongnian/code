    static readonly Regex _routeX = new Regex("foo/(.+)", RegexOptions.Compiled );
    static readonly Regex _routeY = new Regex("baz/(.+)"/qux, RegexOptions.Compiled );
    public void HandleRequest(HttpContext context)
    {
        if( _routeX.IsMatch( context.Request.RawUrl ) )
        {
            context.Response.Write("<xml><myObject>foo</myObject></xml>");
        }
        else if( _routeY.IsMatch( context.Request.RawUrl ) )
        {
            context.Response.Write("<anotherXmlFile>baz</anotherXmlFile>");
        }
    }
