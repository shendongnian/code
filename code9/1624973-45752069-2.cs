    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripTreeView : ToolStripControlHost
    {
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        public TreeView TreeViewControl { get { return (TreeView)Control; } }
        public ToolStripTreeView() : base(CreateControl()) { }
        private static TreeView CreateControl()
        {
            var t = new TreeView();
            return t;
        }
    }
