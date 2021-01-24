    tw =>
        {
            HtmlString htmlString = result as HtmlString;
            if (htmlString != null) {
                tw.Write(htmlString);
                //return;
            }
            if (result != null) {
                tw.Write(HttpUtility.HtmlEncode(result));
            }
            else 
            tw.Write(HttpUtility.HtmlEncode(""));
        }
