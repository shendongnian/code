    public static class ThreadHelper
    {
        private delegate void SetPictureCallback(PBForm f, Image image);
        private delegate void AppendTextCallback(PBForm f, string text);
        public static void SetPicture(PBForm form, Image image)
        {
            if (form.InvokeRequired)
            {
                SetPictureCallback d = SetPicture;
                form.Invoke(d, form, image);
            }
            else
            {
                form.pictureBox1.Image = image;
                form.pictureBox1.Refresh();
            }
        }
        public static void AppendText(PBForm form, string text)
        {
            if (form.InvokeRequired)
            {
                AppendTextCallback d = AppendText;
                form.Invoke(d, form, text);
            }
            else
            {
                form.textBox1.Text += text;
                form.textBox1.SelectionStart = form.textBox1.TextLength - 1;
                form.textBox1.ScrollToCaret();
                form.textBox1.ScrollToCaret();
            }
        }
    }
