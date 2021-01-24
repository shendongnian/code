    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        using(string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop)){
            PB_Picture.Image = ScaleImage(Image.FromFile(droppedfiles[0]), 180, 140);
        }
    }
