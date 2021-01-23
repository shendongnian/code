    if (!string.IsNullOrWhiteSpace(txtTitle.Text))
    {
        file.Tag.Title = new string[] {txtTitle.Text};    // first time
    }
    file.Tag.Performers = new string[] { txtArtist.Text };
    file.Tag.Title = txtTitle.Text;                       //second time
