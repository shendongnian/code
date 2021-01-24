    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static string RootStoragePath =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "YourApplication",
                "ViewState");
        protected string StateFilePath =>
           Path.Combine(RootStoragePath, this.GetType().Name + ".xaml");
        public void Save()
        {
            var fileName = StateFilePath;
            var directoryName = Path.GetDirectoryName(fileName);
            if (directoryName != null && !Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            XamlServices.Save(fileName, this);
        }
        public void Load()
        {
            var fileName = StateFilePath;
            if (File.Exists(fileName))
            {
                using (var file = File.OpenRead(fileName))
                using (var reader = new XamlXmlReader(file))
                {
                    var writer = new XamlObjectWriter(
                        reader.SchemaContext,
                        new XamlObjectWriterSettings { RootObjectInstance = this });
                    using (writer)
                    {
                        XamlServices.Transform(reader, writer);
                    }
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
