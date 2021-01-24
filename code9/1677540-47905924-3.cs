    if (!string.IsNullOrWhiteSpace(line))
    {
        string tempLine = line;
        Task temp = Task.Factory.StartNew(() => AddSearchPlaylistToList(tempLine ));
        tasks.Add(temp);
    }
