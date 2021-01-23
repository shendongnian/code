    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
    public partial class DrawPolygon : Control
    {
        ObservableCollection<PointF> points;
        public DrawPolygon()
        {
            InitializeComponent();
            points = new ObservableCollection<PointF>();
            points.CollectionChanged += Points_CollectionChanged;
        }
        private void Points_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                Refresh();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            points.Add(e.Location);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (points.Count > 1)
                pe.Graphics.DrawPolygon(Pens.Aqua, points.ToArray());
        }
    }
