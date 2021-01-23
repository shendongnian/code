     richTextBox1.Invoke(new EventHandler(delegate
                {
    
    
                        for (int i = 0; i < 10000; i++)
                        {
                            richTextBox1.Text += "s";
                        }
    
                }));
