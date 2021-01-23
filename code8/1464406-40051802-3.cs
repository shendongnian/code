    foreach (Control c in flp.Controls)
    {
        // Check if the control is one of your custom UserControls:
        if (c.GetType() == typeof(Movie))
        {
            // since it is a "Movie", it is safe to cast it:
            Movie movie = (Movie)c;
            if (!movie.Title.ToLower().Contains(searchBox.Text.ToLower()))
            {
                flp.Controls.Remove(c); // remove or keep both the image and text
            }
        }
    }
