    [Serializable]
    public class EnvironmentConfig
    {
        public string Title { get; set; }
        public string XmlPath { get; set; }
        public string SharepointPath { get; set; }
        public List<SubFolder> SubFolders { get; set; }
        public override string ToString()
        {
            return $"{Title}: {XmlPath}, {SharepointPath}, {string.Join(", ", SubFolders.Select(s => s.Folder))}";
        }
    }
    [Serializable]
    public class SubFolder
    {
        public string Folder { get; set; }
        public bool IsStandard { get; set; }
    }
