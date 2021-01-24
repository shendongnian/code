    int flag = 0;
    private void DragOver(object sender, DragEventArgs e)
    {
        if (sender is StackPanel)
        {
            flag = 1;
            //TODO StackPanel DragOver
            Debug.WriteLine(sender.GetType().ToString());
        }else if(sender is GridView && flag == 0)
        {
            //TODO GridView DragOver
            Debug.WriteLine(sender.GetType().ToString());
        }
        flag = 0;
    }
