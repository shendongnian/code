    private void button_Click(object sender, RoutedEventArgs e) 
    {
        string writerfile = @"D:\Games\ukony.txt";
        System.IO.File.WriteAllText(writerFile, this.textBlock.Text);
        System.IO.File.AppendAllText(writerFile, this.textBlock1.Text);
    }
