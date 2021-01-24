    using System;
    using System.Windows.Forms;
    class SelectablePictureBox : PictureBox
    {
        public SelectablePictureBox()
        {
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserMouse, true);
            TabStop = true;
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Invalidate();
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
                ControlPaint.DrawFocusRectangle(pe.Graphics, ClientRectangle);
        }
    }
