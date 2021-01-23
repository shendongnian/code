    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]
    public class CountLinesExtension : SharpContextMenu
    {        
        protected override bool CanShowMenu()
        {
            return true;
        }
     
        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();
     
            //  Create a 'count lines' item.
            var itemCountLines = new ToolStripMenuItem
            {
                Text = "Count Lines...",
                Image = Properties.Resources.CountLines
            };
     
            //  When we click, we'll count the lines.
            itemCountLines.Click += (sender, args) => CountLines();
     
            //  Add the item to the context menu.
            menu.Items.Add(itemCountLines);
     
            //  Return the menu.
            return menu;
        }
     
        private void CountLines()
        {
            // do the work
        }
    } 
