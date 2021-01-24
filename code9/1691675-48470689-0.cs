    // This method is called when MouseButonDown on TreeViewItem and also listen
    // for handled events too.  The purpose is to restore focus on TreeView when
    // mouse is clicked and focus was outside the TreeView.  Focus goes either to
    // selected item (if any) or treeview itself
    internal void HandleMouseButtonDown()
    {
        if (!this.IsKeyboardFocusWithin)
        {
            if (_selectedContainer != null)
            {
                if (!_selectedContainer.IsKeyboardFocused)
                    _selectedContainer.Focus();
            }
            else
            {
                // If we don't have a selection - just focus the TreeView
                this.Focus();
            }
        }
    }
