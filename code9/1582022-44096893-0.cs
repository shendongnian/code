    public class SpecialLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Text.StartsWith("My "))
                return;
            var stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.SetMeasurableCharacterRanges(new []{new CharacterRange(0, 3)});
            var bounds = Rectangle.Round(e.Graphics.MeasureCharacterRanges("My ",
                    Font, e.ClipRectangle, stringFormat)[0]
                .GetBounds(e.Graphics));
            e.Graphics.FillRectangle(new SolidBrush(BackColor), bounds);
        }
    }
