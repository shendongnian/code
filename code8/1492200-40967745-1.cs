        public void CountDown()
        {
            synth.Speak("Starting!");
            for (int i = 10; i >= 0; i--)
            {
                int i2 = i; // take a local copy of the loop variable
                this.Invoke((MethodInvoker)(() => richTextBox1.AppendText(i2 + "\r\n")));
                System.Threading.Tasks.Task.Delay(1000).Wait();
                this.Invoke((MethodInvoker)(() => richTextBox1.Clear()));
            }
        }
