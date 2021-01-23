    public class YourObject 
    {
        private string _output;
        public void button1_Click(object sender, EventArgs args)
        {
            // ...
            _output = output;
        }
        public void label1_Click(object sender, EventArgs e)
        {
            label1.Text = _output;
        }
    }
