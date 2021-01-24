    private void MyMethod(object sender, EventArgs args)
    {
        JRPC.SetMemory(rgh, 0xc035261d, reverseBytes(textBox1.Text));
        JRPC.SetMemory(rgh, 0xc035261c, getBytes(Encoding.ASCII.GetBytes(textBox1.Text + "\0")));
    }
