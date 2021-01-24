    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class MyCustomRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);
            e.ToolStrip.Items.OfType<ToolStripTrackBar>()
             .ToList().ForEach(item =>
             {
                 if (item.Image != null)
                 {
                     var size = item.GetCurrentParent().ImageScalingSize;
                     var location = item.Bounds.Location;
                     location = new Point(5, location.Y + 1);
                     var imageRectangle = new Rectangle(location, size);
                     e.Graphics.DrawImage(item.Image, imageRectangle,
                         new Rectangle(Point.Empty, item.Image.Size),
                         GraphicsUnit.Pixel);
                 }
             });
        }
    }
