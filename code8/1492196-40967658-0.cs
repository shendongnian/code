    public partial class Form1 : Form
    {
    private static SpeechSynthesizer synth = new SpeechSynthesizer();
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        richTextBox1.AppendText("A button was clicked\r\n");
    }
    private void button2_Click(object sender, EventArgs e)
    {
        CountDown();
    }
    public void CountDown()
    {
    new Thread(() =>
    {
     Thread.CurrentThread.IsBackground = true;
      synth.Speak("Starting!");
        for (int i = 10; i >= 0; i--)
        {
            richTextBox1.AppendText(i + "\r\n");
            System.Threading.Tasks.Task.Delay(1000).Wait();
            richTextBox1.Clear();
        }
    }).Start();
        
     }
    }
    }`
