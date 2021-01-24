    private async Task WriteTextChain(string text, int delay, int chain)
    // returning Task allows you to await call to this function
        {
            for (int i = 0; i < chain; i++)
            {
                rtbOutput.AppendText(text);
                await Task.Delay(delay);
            }
        }
    
     private async void button2_Click(object sender, EventArgs e)
        {
            await WriteTextChain("string 1 \n", 1000, 3); // await makes execution of next line to wait for this line completion
            await WriteTextChain("string 2 \n", 300, 6);
        }
        /* output reads
            string 1
            string 1
            string 1
            string 1
            string 2
            string 2
            string 2
            string 2
            string 2
        */
