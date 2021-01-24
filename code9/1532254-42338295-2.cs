    using System.Drawing;
    
    public class GImageMarker : GMapMarker
    {
        public Bitmap Bitmap { get; set; }
    
        public GImageMarker(PointLatLng p, Bitmap Bitmap)
            : base(p)
        {
            this.Bitmap = Bitmap;
            Size = new System.Drawing.Size(Bitmap.Width, Bitmap.Height);
            Offset = new Point(-Size.Width / 2, -Size.Height);
        }
    
        public override void OnRender(Graphics g)
        {
             g.DrawImage(Bitmap, LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
        }
    }
