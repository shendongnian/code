    /// <summary>
    /// Subclass catches exception thrown from base.OnPaint and thus prevents the red x.
    /// Resets base classes private field "disableInvalidates" via reflection to reallow invalidation.
    /// </summary>
    public class ChartSubclass : Chart
    {
        private readonly System.Reflection.FieldInfo disableInvalidatesField;
        public ChartSubclass()
        {
            this.disableInvalidatesField = typeof(Chart).GetField("disableInvalidates",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.SetField |
                System.Reflection.BindingFlags.Instance);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                this.disableInvalidatesField.SetValue(this, false);
                this.DrawErrorState(e, ex);
            }
        }
        /// <summary>
        /// Draws error message.
        /// </summary>
        private void DrawErrorState(PaintEventArgs e, Exception ex)
        {
            var graphics = e.Graphics;
            graphics.FillRectangle(Brushes.White, 0, 0, base.Width, base.Height);
            var layoutRectangle = new RectangleF(3f, 3f, base.Width - 6, base.Height - 6);
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString(ex.Message, this.Font, Brushes.Black, layoutRectangle, stringFormat);
            }
        }
    }
