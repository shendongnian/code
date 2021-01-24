    public partial class MainWindow: Window
    {
        ObservableCollection<string> files = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            cc.Collection = files;
        }
        private void New_Selected(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (.bmp, .jpg, .gif, .png, .tiff)|*.bmp;*.jpg;*.gif;*.png;*.tiff";
            if (dlg.ShowDialog(this) == true)
            {
                // Add selected file to the list
                string name = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    files.Add(name);
                    // Deselect `Add New` item
                    selector.SelectedIndex = -1;
                }));
            }
        }
    }
