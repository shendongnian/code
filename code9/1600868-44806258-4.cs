    public class SettingsPathSelectorViewModel : ViewModelBase
    {
        #region Label Property
        private String _label = default(String);
        public String Label
        {
            get { return _label; }
            set
            {
                if (value != _label)
                {
                    _label = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion Label Property
        #region SettingsPath Property
        private String _settingsPath = null;
        public String SettingsPath
        {
            get { return _settingsPath; }
            set
            {
                if (value != _settingsPath)
                {
                    _settingsPath = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion SettingsPath Property
        public ICommand OpenFile
        {
            get
            {
                bool CanExecuteOpenFileCommand()
                {
                    return true;
                }
                //  We're no longer using the parameter, since we now have one                 
                //  command per SettingsPath. 
                CommandHandler GetOpenFileCommand()
                {
                    return new CommandHandler((o) =>
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Multiselect = false;
                        if (!string.IsNullOrEmpty(SettingsPath) && System.IO.File.Exists(SettingsPath))
                        {
                            ofd.InitialDirectory = System.IO.Path.GetDirectoryName(SettingsPath);
                        }
                        if (ofd.ShowDialog() == true)
                        {
                            SettingsPath = ofd.FileName;
                        }
                    }, o => CanExecuteOpenFileCommand());
                }
                return GetOpenFileCommand();
            }
        }
    }
