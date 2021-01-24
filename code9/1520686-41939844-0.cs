    public static class ControlExt
    {
        public static void InvokeChecked(this Control control, Action method)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(method);
                }
                else
                {
                    method();
                }
            }
            catch { }
        }
    }
    public partial class Form1 : Form
    {
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            this.InvokeChecked(delegate
            {
                richTextBox1.Text += serialPort1.ReadExisting() + "\n";
                richTextBox1.SelectionStart = Text.Length;
                richTextBox1.ScrollToCaret();
            });
        }
    }
