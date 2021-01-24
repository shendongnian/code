    try
    {
        var img = System.Drawing.Image.FromStream(file.OpenReadStream());
    }
    catch
    {
        // bad image
    }
