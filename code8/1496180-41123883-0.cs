    bool done;
    do
    {
        done = true;
        for (int index = CLB.Items.Count; index > 0; index--)
        {
            if(CLB.CheckedItems.Contains(CLB.Items[index-1]))
            {
                CLB.Items.RemoveAt(index - 1);
                done = false;
                break;
            }
        }
    
    }while(!done);
    
