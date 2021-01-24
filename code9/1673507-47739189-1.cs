    private void MyControl_DragEnter(object sender, DragEventArgs e)
    {
        /*
        DragDropEffects
        */
        e.Effect = DragDropEffects.Copy; 
    }
    private void MyControl_DragDrop(object sender, DragEventArgs e)
    {
        TextBox tb = e.Data.GetData(typeof(TextBox)) as TextBox;
        /*
        MyControl.Controls.Add(tb);
        * Your code here
        */
    }
