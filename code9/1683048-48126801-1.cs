    public partial class Form1 : Form
    {
        // ...whatever is in your form already...
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2.Enabled = true;
            isInGui = false;
        }
        // ...
    }
