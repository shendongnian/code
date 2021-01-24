    public class ExtensionGroup
    {
        public string Name {get; set;}
        public ObservableCollection<ExtensionInfo> ExtensionInfos {get; set;}
    }
    
    public class ExtensionInfo
    {
        public string Extension {get; set;}
        public bool IsChecked {get; set;}
        public ExtensionInfo(string extension)
        {
            Extension = extension;
        }
    }
