    public class Template : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SerializableBrush _WindowBG = new SerializableColorBrush(SystemColors.AppWorkspaceBrush);
        [JsonProperty(TypeNameHandling = TypeNameHandling.All)]
        public SerializableBrush WindowBG { get { return _WindowBG; } set { if (value != _WindowBG) { _WindowBG = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WindowBG")); } } }
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
