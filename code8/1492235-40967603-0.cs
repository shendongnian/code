    public static void CountDown()
    {
        synth.Speak("Starting!");
        for (int i = 10; i >= 0; i--)
        {
           richTextBox1.AppendText(i + "\r\n");
           System.Threading.Tasks.Task.Delay(1000).Wait();
            richTextBox1.Clear();
        }
      }
