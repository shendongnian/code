      private void DefineContextMenu()
        {
            // Create an array with actual size.
            ToolStripMenuItem[] arrayOfToolStripItems = new ToolStripMenuItem[menuView.DropDownItems.Count];
            int counter = 0;
            foreach (ToolStripMenuItem t in menuView.DropDownItems)
            {
                arrayOfToolStripItems[counter] = t;
                counter++;
            }
            // takes an array
            ctxtMenuView.Items.AddRange(arrayOfToolStripItems);
        }
