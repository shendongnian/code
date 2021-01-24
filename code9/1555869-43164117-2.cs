    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripTrackBar : ToolStripControlHost
    {
        public TrackBar TrackBar { get { return (TrackBar)Control; } }
        public ToolStripTrackBar() : base(CreateControl()) { }
        private static TrackBar CreateControl()
        {
            var t = new TrackBar()
            { TickStyle = TickStyle.None, AutoSize = false, Height = 28 };
            return t;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Image Image
        {
            get { return base.Image; }
            set { base.Image = value; }
        }
        /*Expose properties and events which you need.*/
        public int Value
        {
            get { return TrackBar.Value; }
            set { TrackBar.Value = value; }
        }
    }
