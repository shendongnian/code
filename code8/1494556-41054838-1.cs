     public partial class RedPointDrawer : Component
        {
            /// <summary>
            /// Get: Dictionary of bound Controls which become a RedPoint with number of notifications
            /// </summary>
            public Dictionary<Control, int> Controls { get; }
    
            /// <summary>
            /// 
            /// </summary>
            public RedPointDrawer()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="container"></param>
            public RedPointDrawer(IContainer container)
            {
                container.Add(this);
                InitializeComponent();
                Controls = new Dictionary<Control, int>();
            }
    
            /// <summary>
            /// Draws a RedPoint to all 
            /// </summary>
            public void ActivateRedPoint()
            {
                foreach (Control control in Controls.Keys)
                {
                    control.Paint += Control_Paint;
                }
            }
    
            private void Control_Paint(object sender, PaintEventArgs e)
            {
                int count;
                var control = sender as Control;
    
                if (control != null &&
                    Controls.TryGetValue(control, out count))
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        Rectangle rectangle = new Rectangle(e.ClipRectangle.X + e.ClipRectangle.Width - 10, 0, 10, 10);
    
                        e.Graphics.DrawEllipse(pen, rectangle);
                        e.Graphics.FillEllipse(new SolidBrush(Color.Red), rectangle);
                        e.Graphics.DrawString(count.ToString(), new Font(new FontFamily("Arial"), 8), new SolidBrush(Color.White),
                            rectangle.X,
                            rectangle.Y);
                    }
                }
            }
        }
