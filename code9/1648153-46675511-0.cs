    public class CenteredDateTimePicker : DateTimePicker
    {
        public CenteredDateTimePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }
    }
