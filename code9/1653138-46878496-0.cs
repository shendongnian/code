    public static class ToolStripMenuItemExtensions
    {
        public static List<ToolStripMenuItem> Descendants(this ToolStripMenuItem item)
        {
            var items = item.DropDownItems.OfType<ToolStripMenuItem>().ToList();
            return items.SelectMany(x => Descendants(x)).Concat(items).ToList();
        }
    }
