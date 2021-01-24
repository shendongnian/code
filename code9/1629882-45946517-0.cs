    public class XmlFile : INotifyPropertyChanged
    {
        private string _xmlfile;
        private string _xmlElementName;
        public string XMLFile
        {
            get { return _xmlfile; }
            set
            {
                if (value != _xmlfile)
                {
                    _xmlfile = value;
                    _xmlElementName = SetElementNameFromFileName();
                    OnPropertyChanged(nameof(XMLFile);
                }
            }
        }
    ...
    }
     private void xmlFilePath_Drop(object sender, DragEventArgs e)
        {
            var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filenames == null) return;
            var filename = filenames.FirstOrDefault();
            if (filename == null) return;
            //XmlFileInfo.XMLFile = filename; <-- This bypasses the binding
            var viewModel = (XmlFile)this.DataContext;
            viewModel.XMLFile = filename;
            SetControlState(); //<-- enables a button control if file is valid
        }
