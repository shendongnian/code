    public partial class Form1 : Form
    {
        delegate void FileCreationUpdater(FileSystemEventArgs evt);
        FileSystemWatcher watcher = null;
        public Form1()
        {
            InitializeComponent();
            // instantiate a new FileSystemWatcher
            watcher = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            {
                // and starts it right away
                EnableRaisingEvents = true
            };
            
            // create a new updater delegate 
            FileCreationUpdater updater = new FileCreationUpdater(TextBoxUpdater);
            
            // when receiving Created events, Invoke updater.
            watcher.Created += (s, e) =>
            {
                /// passing parameter to the invoked method
                textBox1.BeginInvoke(updater, e);
            };
        }
        public void TextBoxUpdater(FileSystemEventArgs evt)
        {
            /// update path
            textBox1.Text = evt.FullPath;
        }
    }
