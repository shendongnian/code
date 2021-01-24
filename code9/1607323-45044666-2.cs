        private void EnableContextMenu()
        {
            for (int i = 0; i < contextMenu.MenuItems.Count; i++)
            {
                if (_isInSelectedText == true && _isTextSelected)
                {
                    contextMenu.MenuItems[i].Enabled = true;
                }
                else
                {
                    contextMenu.MenuItems[i].Enabled = false;
                }
            }
        }
