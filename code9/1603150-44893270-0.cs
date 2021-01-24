    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
        using (var image = Image.FromFile(droppedfiles[0])){
            PB_Picture.Image = ScaleImage(image, 180, 140);
        }
    }
