     TelegramBotClient Bot = new TelegramBotClient("MyToken");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;
        }
        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            MessageBox.Show(e.Message.Text);
        }
