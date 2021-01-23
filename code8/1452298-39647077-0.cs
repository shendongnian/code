    private void button1_Click(object sender, EventArgs e)
    {
       string s = File.ReadAllText("D:\\test.img");
       var array = s.split("xxxyyyzzz", StringSplitOptions.None);
       forEach(string s in array)
       {
           listBox1.Items.Add(s);
       }
    }
    
