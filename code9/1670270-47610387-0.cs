    private void button1_Click(object sender, EventArgs e)
    {
        TextWriter txt = new StreamWriter("d:\\demo.txt");
        txt.WriteLine(textBox1.Text);
        txt.Close();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(@"d:\\demo.txt"); 
    
        while((line = file.ReadLine()) != null)  
        {  
            if (line.ToLower().StartsWith("a"))
            {
                textBox2.Text += " " + line;
            }
        } 
    } 
