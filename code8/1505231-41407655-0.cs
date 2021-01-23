    int count = 10;
            async Task MethodAsyncs()
            {
                for (int i = 0; i < count; i++)
    
                {
                    textBox1.Text += "x";
                    await Task.Delay(500);
                }
            }
