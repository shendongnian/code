    private void button_Click(object sender, RoutedEventArgs e) 
    {
        string writerfile = @"D:\Games\ukony.txt";
        using (StreamWriter writer = new StreamWriter(writerfile)) 
        {
            writer.WriteLine(textBlock.Text);
            writer.WriteLine(textBlock1.Text);
        }
    }
