    private void ImageView_Click(object sender, EventArgs e)
            {
                Random r = new Random();
                int index = r.Next() % 36;
                String name = "s" + index;
                int drawableId = Resources.GetIdentifier(
                                    name,               // the name of the resource
                                    "drawable",         // type of resource
                                    "Us.Us"); // your app package name
                imageView.SetImageResource(drawableId);
    
            }
