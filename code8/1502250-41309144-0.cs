        private Client client;
        public MainWindow()
        {
            InitializeComponent();
            var vault = new Vault();
            client = new Client(vault.GetAccountId(), vault.GetApiKey());
            Auth();
        }
        private async void Auth()
        {
            await client.Authorize();
        }
