    public partial class Form1 : Form
    {
        public SpeechRecognitionEngine recEngine;
        public static bool keyHold = false;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantiate the Recognition At Class Level
            recEngine = new SpeechRecognitionEngine();
        
            // Add Events
            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recEngine_SpeechRecognized);
            recEngine.AudioStateChanged += new EventHandler<AudioStateChangedEventArgs>(recEngine_AudioStateChange);
            Choices commands = new Choices();
            commands.Add(new string[] { "dollar", "euro", "hotmail", "notepad", "outlook", "onedrive", "discord" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.LoadGrammarAsync(grammar);
            recEngine.RequestRecognizerUpdate();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            //recEngine.SpeechRecognized -= recEngine_SpeechRecognized;
            //recEngine.AudioStateChanged -= recEngine_AudioStateChange;
        }
        internal void recEngine_AudioStateChange(object sender, AudioStateChangedEventArgs e)
        {
            textBox1.Text = string.Format("Audio state: {0}", e.AudioState);
        }
        internal static void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "notepad":
                    System.Diagnostics.Process.Start("notepad.exe");
                    break;
                case "hotmail":
                    System.Diagnostics.Process.Start("https://outlook.live.com/owa/");
                    break;
                case "outlook":
                    System.Diagnostics.Process.Start("https://outlook.live.com/owa/");
                    break;
                case "ondrive":
                    System.Diagnostics.Process.Start("https://onedrive.live.com/");
                    break;
                case "discord":
                    string name = Environment.UserName;
                    string path = string.Format(@"C:\Users\{0}\AppData\Local\Discord\app-0.0.300\Discord.exe", name);
                    System.Diagnostics.Process.Start(path);
                    break;
            }
        }
    }
    
