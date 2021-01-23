    public ActionResult SetCulture( string lan ) {
            string Culture = Request.QueryString.Get( "lan" );
            var returnUrl = Request.UrlReferrer;
            // Validate input
            Culture = CultureHelper.GetImplementedCulture( Culture );
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies[ "_culture" ];
            if ( cookie != null )
                cookie.Value = Culture;   // update cookie value
            else {
                cookie = new HttpCookie( "_culture" );
                cookie.Value = Culture;
                cookie.Expires = DateTime.Now.AddYears( 1 );
            }
            Response.Cookies.Add( cookie );
            //Session["_culture"] = Culture;
            return Redirect( returnUrl.OriginalString );
        }
