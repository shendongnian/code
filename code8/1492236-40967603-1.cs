    namespace okey
    {
      public partial class Form1 : Form
      {
         Thread countdown;
         private SpeechSynthesizer synth = new SpeechSynthesizer();
         public Form1()
         {
           InitializeComponent();
           countdown = new Thread(new ThreadStart(CountDown));
         }
         private void button1_Click(object sender, EventArgs e)
         {
           countdown.Start();
         }
        private void button2_Click(object sender, EventArgs e)
        {
          countdown.Abort();
        }
        public void CountDown()
        {
          synth.Speak("Starting!");
          for (int i = 10; i >= 0; i--)
          {
            richTextBox1.AppendText(i + "\r\n");
            System.Threading.Tasks.Task.Delay(1000).Wait();
            richTextBox1.Clear();
          }
         }
       } 
    }
