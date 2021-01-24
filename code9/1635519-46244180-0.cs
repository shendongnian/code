    public NotifyTask<List<VideoListItem>> VideoItems { get; }
    public VideoListModel(IKnownFolderReader knownFolder)
    {
      _knownFolder = knownFolder;
      VideoItems = NotifyTask.Create(() => _knownFolder.GetData());
    }
