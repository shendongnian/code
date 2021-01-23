    foreach (FileInfo file in Files)
    {
        MusicFileModel temp = new MusicFileModel();
        temp.Name = file.Name.ToString();
        temp.Pfad = file.DirectoryName.ToString();
        FileList.Add(temp);
        Debug.WriteLine(temp.Name + ", " + temp.Pfad);
    }
