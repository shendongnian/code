    private void ToggleAll()
    {
        // Prevent tree from being modified while the values are being updated.
        TreeIsEnabled = false; // Bound to IsEnabled on TreeView
    
        // My attempt to update the UI from another thread.
        Task task = new Task(() =>
        {
            // Update each child's ViewModel
            foreach (TreeViewModelBase child in GetChildren())
            {
                child.ToBeProcessed = CheckAll;
            }
        });
        task.Start();
    
        // Re-enable the tree when the await is finished.
        TreeIsEnabled = true;
    }
