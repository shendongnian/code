    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static string RootStoragePath =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "YourApplication",
                "ViewState");
        private string StateFile => GetType().Name + ".xaml";
        private static string EnsureStoragePath()
        {
            var path = RootStoragePath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public void Save()
        {
            XamlServices.Save(Path.Combine(EnsureStoragePath(), StateFile), this);
        }
        public void Load()
        {
            var fileName = Path.Combine(EnsureStoragePath(), StateFile);
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
