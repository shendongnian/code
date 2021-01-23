    if (!System.IO.File.Exists(filename))
    {
        SaveXml.SaveData(info, filename);
    }
    else
    {
        // notify that name is imabiguous
    }
