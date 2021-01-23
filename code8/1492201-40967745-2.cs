        private async void button2_Click(object sender, EventArgs e)
        {
            synth.Speak("Starting!");
            for (int i = 10; i >= 0; i--)
            {
                richTextBox1.AppendText(i + "\r\n");
                await System.Threading.Tasks.Task.Delay(1000);
                richTextBox1.Clear();
            }
        }
