    if (File.Exists(Server.MapPath("product.jpg")))
    {
        ProductThumbnail1.Visible = true;
        Imagealt.Visible = false;
    }
    else
    {
        ProductThumbnail1.Visible = false;
        Imagealt.Visible = true;
    }
