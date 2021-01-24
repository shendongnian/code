    for(int i = 0; i < 5; i++)
    {
        lblInfo.InnerText = artist;
        string name = (stuff.topalbums.album[i].name.ToString());
        string playcount = stuff.topalbums.album[i].playcount.ToString();
        string image = stuff.topalbums.album[i].image[2].text.ToString();
        //System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)e.Row.Cells[2].FindControl("Image1");
        //img.ImageUrl = image;
        dt.Rows.Add(artist, name, playcount, image);
    }
