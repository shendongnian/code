    public class MainViewModel : ViewModelBase
    {
    
        private bool _sixtyFourBitCheck;
        private bool _packegeCheck;
        private bool _setupCheck;
        private bool _ftpUploadCheck;
        public int _windowHeight;
        public int _origSize = 200;
    
    
        public bool SixtyFourBitCheck
        {
            get => _sixtyFourBitCheck;
            set
            {
                if (value == _sixtyFourBitCheck) return;
                _sixtyFourBitCheck = value;
                OnPropertyChanged();
            }
        }
    
        public bool PackegeCheck
        {
            get => _packegeCheck;
            set
            {
                if (value == _packegeCheck) return;
                _packegeCheck = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PackageDestinationVisibility));
                ChangeWindowsHeght();
            }
        }
    
        public bool SetupCheck
        {
            get => _setupCheck;
            set
            {
                if (value == _setupCheck) return;
                _setupCheck = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SetupDestinationVisibility));
                ChangeWindowsHeght();
            }
        }
    
        public bool FtpUploadCheck
        {
            get => _ftpUploadCheck;
            set
            {
                if (value == _ftpUploadCheck) return;
                _ftpUploadCheck = value;
                OnPropertyChanged();
            }
        }
    
        public bool SetupDestinationVisibility => SetupCheck;
    
        public bool PackageDestinationVisibility => PackegeCheck;
    
        public int WindowHeight
        {
            get => _windowHeight;
            set
            {
                if (value == _windowHeight) return;
                _windowHeight = value;
                OnPropertyChanged();
            }
        }
    
        public MainViewModel()
        {
            WindowHeight = _origSize;
        }
    
        private void ChangeWindowsHeght()
        {
            WindowHeight = _origSize;
            if (PackageDestinationVisibility)
                WindowHeight += 35;
            if (SetupDestinationVisibility)
                WindowHeight += 35;
            OnPropertyChanged(nameof(WindowHeight));
        }
    }
