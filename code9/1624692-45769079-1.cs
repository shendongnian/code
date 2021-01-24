    string url = ((Image)gvImages.Items[e.Item.ItemIdex].FindControl("PICID")).ImageUrl;
    string path = Server.MapPath(url);
    if (File.Exists(path))
    {
        File.Delete(path); // deletes file from folder
    }
    
