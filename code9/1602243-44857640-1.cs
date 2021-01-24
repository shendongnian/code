    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Link;
        }
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        string filePath = ((string[]) e.Data.GetData(DataFormats.FileDrop))[0];
        ....
