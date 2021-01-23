        public MainPage()
        {
            this.InitializeComponent();
            InitRC522Async();
        }
        private async void InitRC522Async()
        {
            var mfrc = new Mfrc522();
            await mfrc.InitIO();
            while (true)
            {
                if (mfrc.IsTagPresent())
                {
                    var uid = mfrc.ReadUid();
                    mfrc.HaltTag();
                }
            }
        }
