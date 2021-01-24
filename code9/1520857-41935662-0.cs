           public void MoveUp()
        {
            MoveItem(-1);
        }
        public void MoveDown()
        {
            MoveItem(1);
        }
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (yourListBox.SelectedItem == null || yourListBox.SelectedIndex < 0)
                return; // No selected item - nothing to do
            // Calculate new index using move direction
            int newIndex = yourListBox.SelectedIndex + direction;
            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= yourListBox.Items.Count)
                return; // Index out of range - nothing to do
            object selected = yourListBox.SelectedItem;
            // Removing removable element
            yourListBox.Items.Remove(selected);
            // Insert it in new position
            yourListBox.Items.Insert(newIndex, selected);
            // Restore selection
            yourListBox.SetSelected(newIndex, true);
        }
