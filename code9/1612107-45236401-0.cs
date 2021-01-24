    // We require a list to remember which items should stay selected
    private List<Item> _MultiSelectList;
    public Form1() {
        // <other stuff>
        _MultiSelectList = new List<Item>();
    }
    // use this event to check which item has been clicked
    private void objectListView1_MouseClick(object sender, MouseEventArgs e) {
        objectListView1.BeginUpdate();
        // any item clicked?
        if (objectListView1.MouseMoveHitTest.Item != null) {
            var item = objectListView1.MouseMoveHitTest.Item.RowObject as Item;
            
            // model object of expected type available?
            if (item != null) {
                // add or remove item from list to effectively toggle selection
                if (_MultiSelectList.Contains(item)) {
                    _MultiSelectList.Remove(item);
                } else {
                    _MultiSelectList.Add(item);
                }
            }
        }
        // select all desired items
        objectListView1.SelectObjects(_MultiSelectList);
        objectListView1.EndUpdate();
    }
    // optional: to prevent flickering from the native item selection change, we freeze the OLV contents during the mouse click
    private void objectListView1_MouseDown(object sender, MouseEventArgs e) {
        objectListView1.Freeze();
    }
    private void objectListView1_MouseUp(object sender, MouseEventArgs e) {
        objectListView1.Unfreeze();
    }
