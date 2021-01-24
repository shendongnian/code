    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class MyDataGridView : DataGridView
    {
        public MyDataGridView() { DoubleBuffered = true; }
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if (this.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                using (var b = new SolidBrush(Color.FromArgb(50, Color.Blue)))
                using (var p = new Pen(Color.Blue))
                {
                    var r = e.RowBounds; r.Width -= 1; r.Height -= 1;
                    e.Graphics.FillRectangle(b, r);
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e){
            base.OnMouseMove(e); this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e){
            base.OnMouseEnter(e); this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e){
            base.OnMouseLeave(e); this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs e){
            base.OnScroll(e); this.Invalidate();
        }
    }
