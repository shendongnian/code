    var finalList = new List<string>();
    foreach (string file in condensedFilesList)
    {
        Image imgToAdd;
        using(var imgToAdd = Image.FromFile(file))
        {
            if (imgToAdd.Width < 1920 || imgToAdd.Height < 1080)
            {
                /* omit */
            }
            else
            {
                finalList.Add(file);
            }
        }
    }
