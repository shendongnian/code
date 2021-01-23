    try
    {
        using (StreamReader sr = new StreamReader(Application.Context.Assets.Open(data[position].image)))
        {
            using (var d = Drawable.CreateFromStream(sr.BaseStream, null))
            {
                imgThumbnail.SetImageDrawable(d);
            }
        }
    }
    catch
    {
        imgThumbnail = null;
    }
