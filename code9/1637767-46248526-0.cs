    @using System.Web.UI.HtmlControls;
    
        // build facebook meta
        HtmlMeta metaOGTitle = new HtmlMeta();
        metaOGTitle.Attributes.Add("property", "og:title");    
        metaOGTitle.Content = post.Title;
        HtmlMeta metaOGImage = new HtmlMeta();
        metaOGImage.Attributes.Add("property", "og:image");    
        metaOGImage.Content = post.Image.ToLower();
    
        // change the title and add facebook meta      
        var pageObj = Context.CurrentHandler as Page;
        pageObj.Title = post.Title;
        pageObj.FindControl("Head").Controls.Add(metaOGTitle);
        pageObj.FindControl("Head").Controls.Add(metaOGImage);
