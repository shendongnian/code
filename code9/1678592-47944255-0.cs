    public class SlowWriter
    {
        public static void Write(string text, Label lbl)
        {
            Task.Run(() =>
            {
                Random rnd = new Random();
                StringBuilder sb = new StringBuilder();
                foreach (char c in text)
                {
                    sb.Append(c);
                    if (lbl.InvokeRequired)
                    {
                        lbl.Invoke((MethodInvoker)delegate { lbl.Text = sb.ToString(); });
                    }
                    else
                    {
                        lbl.Text = sb.ToString();
                    }
                    Thread.Sleep(rnd.Next(30, 60));
                }
            });
        }
    }
