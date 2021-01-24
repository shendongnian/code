    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Nequeo.Net.Translator.Microsoft.Cognitive.SpeechApi apiat = null;
        private void button1_Click(object sender, EventArgs e)
        {
            apiat = new Nequeo.Net.Translator.Microsoft.Cognitive.SpeechApi(new Uri("wss://dev.microsofttranslator.com/speech/"));
            apiat.Credentials = new System.Net.NetworkCredential("[KEY]", "[KEY]");
            string token = apiat.GetAccessToken(new Uri("https://api.cognitive.microsoft.com/sts/v1.0/"));
            apiat.OnRecording += Apiat_OnRecording;
            apiat.OnStopRecording += Apiat_OnStopRecording;
            apiat.OnTranslationReceived += Apiat_OnTranslationReceived;
            Nequeo.IO.Audio.Device device_in = Nequeo.IO.Audio.Devices.GetDeviceIn(0);
            apiat.AudioDevice = device_in;
            apiat.WriteStream = new System.IO.MemoryStream();
            apiat.Translate("hr-HR", "en-US", token);
        }
        private void Apiat_OnTranslationReceived(object sender, EventArgs e)
        {
            System.IO.MemoryStream jj = (System.IO.MemoryStream)apiat.WriteStream;
            string gg = Encoding.Default.GetString(jj.ToArray());
            Nequeo.Net.Translator.Microsoft.Cognitive.SpeechTranslation dffddf = apiat.GetSpeechTranslation();
        }
        private void Apiat_OnStopRecording(object sender, EventArgs e)
        {
            bool kk = true;
            
        }
        private void Apiat_OnRecording(object sender, EventArgs e)
        {
            bool kk = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            apiat.StopTranslate();
        }
    }
    
