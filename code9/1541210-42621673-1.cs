    <ListView x:Name="DropList" 
              Drop="DropList_Drop" 
              DragEnter="DropList_DragEnter" 
              AllowDrop="True" />     
     
     
    private void DropList_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(DataFormats.FileDrop)) // checks for File
        {
            e.Effects = DragDropEffects.None;
        }
    }
