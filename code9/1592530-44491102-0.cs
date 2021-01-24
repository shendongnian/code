    private Object filesLock = new Object();
    
    private void RepopulateResourceSelector()
    {
        // Remove all but the bottom 2 items
        while (selector.Items.Count > 2)
        {
            selector.Items.RemoveAt(0);
        }
        int index = 0;
        lock(filesLock){
            // Add all strings in the list to combo box
            foreach (var file in files)
            {
                selector.Items.Insert(index, file);
                index++;
            }
        }
    }
