    public class CustomWriter : TextWriter
    {
        public override void WriteLine(string value)
        {
            textBox1.Text += value + Environment.NewLine
        }
        // ... etc.
    }
