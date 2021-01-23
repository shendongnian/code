     MusicFileModel temp = new MusicFileModel();
    
            foreach (FileInfo file in Files)
            {
                temp.Name = file.Name.ToString();
                temp.Pfad = file.DirectoryName.ToString();
    
                FileList.Add(temp);
    
                Debug.WriteLine(temp.Name + ", " + temp.Pfad);
            }
