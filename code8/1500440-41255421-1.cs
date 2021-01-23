    foreach(WebControl c in FindControl( Page, c => (c is WebControl) && 
                           ((WebControl)c).CssClass == "redRow" ))
    {
         //Do your operation.
    }
