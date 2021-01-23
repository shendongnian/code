        try
        {
            using (StreamReader sr = new StreamReader(Application.Context.Assets.Open(data[position].image)))
            {
                Drawable d = Drawable.CreateFromStream(sr.BaseStream, null);
                imgThumbnail.SetImageDrawable(d);
            }
        }
        catch
        {
            imgThumbnail = null;
        }
