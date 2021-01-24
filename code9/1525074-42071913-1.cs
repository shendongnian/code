        private Color OriginalColor = Color.WhiteSmoke;
        private int TimeToColorInMiliSeconds = 2000;
        private void button1_Click(object sender, EventArgs e)
        {
            ColorForTwoSeconds(button1);
        }
        private void ColorForTwoSeconds(Button button)
        {
            button.BackColor = Color.Red;
            Task.Run(() => ResetBackColor());
        }
        private void ResetBackColor()
        {
            Thread.Sleep(TimeToColorInMiliSeconds);
            button1.BeginInvoke((MethodInvoker) delegate
            {
                button1.BackColor = OriginalColor;
            });   
        }
