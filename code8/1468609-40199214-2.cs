    public partial class Form1 : Form
    {
        string textEntered = "";
        string response = "";
        SpeechSynthesizer synth = new SpeechSynthesizer();
        bool hasBotBeenCreated = false;
        SimlBot simlBot;
        BotUser botUser;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textEntered = textBox1.Text;
            textBox1.Text = "";
            if (textEntered != "")
            {
                sendToAI(textEntered);
            }
        }
        void sendToAI(string textReceived)
        {
            listBox1.Items.Add(textEntered);
            response = getResponse(textEntered);
            listBox1.Items.Add(response);
            synth.Speak(response);
        }
        string getResponse(string textReceived)
        {
            if (hasBotBeenCreated == false)
            {
                simlBot = new SimlBot();
                botUser = simlBot.CreateUser();
                var packageString = File.ReadAllText("SIMLPackage.simlpk");
                simlBot.PackageManager.LoadFromString(packageString);
            }
            var chatRequest = new ChatRequest(textReceived, botUser);//These two can't access the objects created above
            var chatResult = simlBot.Chat(chatRequest);
            if (chatResult.Success)
            {
                var botMessage = chatResult.BotMessage;
                return botMessage;
            }
            else
            {
                return "I don't have a response for that";
            }
        }
    }
