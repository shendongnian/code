    public class CustomGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Azure, this.ClientRectangle);
            //base.OnPaint(e);
        }
    }
