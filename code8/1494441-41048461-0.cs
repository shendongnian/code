    foreach (string file in condensedFilesList.ToList())
    {
        using(var imgToAdd = Image.FromFile(file))
        {
            if (imgToAdd.Width < 1920 || imgToAdd.Height < 1080)
            {
                condensedFilesList.Remove(file);
            }
        }
    }
