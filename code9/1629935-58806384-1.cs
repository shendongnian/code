    private void DefineContextMenu()
        {
            ToolStripItem[] toolArr = new ToolStripItem[menuView.DropDownItems.Count];
            int count = 0;
            foreach(ToolStripItem t in menuView.DropDownItems)
            {
                toolArr[count] = t;
                count++;
            }
            ctxtMenuView.Items.AddRange(toolArr);
            menuView.DropDown = ctxtMenuView;
        }
