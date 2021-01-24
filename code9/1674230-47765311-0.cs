    public partial class Form1 : Form
    {
        int _position = 0;
        string _text = string.Empty;
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                DisplayText(@"//Displays text at a certain speed test...");
        }
    
        //Displays text at a certain speed
        public void DisplayText(string text, int speed = 200, Color color = default(Color), bool newLine = false)
        {
            _position = 0;
            _text = text;
            timer1.Interval = speed;
    
            timer1.Enabled = true;
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_position < _text.Length)
                Debug.Write(_text[_position]);
            else
                timer1.Enabled = false;
            _position++;
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                timer1.Interval = 15;
        }
    
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer1.Interval = 200;
        }
    }
