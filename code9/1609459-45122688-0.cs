    public void say(string h)
    {
        System.Console.WriteLine();
        textBox1.AppendText(h);
    }
    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        say("Online ...");
        say("What is you Name?");
    }
