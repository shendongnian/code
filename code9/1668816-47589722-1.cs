    public class CustomLabelProvider : ILabelProvider
    {
        public static DateTime Origin = new DateTime(2000, 1, 1);
        public FrameworkElement[] GetLabels(double[] ticks)
        {
            if (ticks == null)
                throw new ArgumentNullException("ticks");
            List<TextBlock> Labels = new List<TextBlock>();
            foreach (double tick in ticks)
            {
                TextBlock text = new TextBlock();
                var time = Origin + TimeSpan.FromHours(tick);
                text.Text = time.ToShortTimeString();
                Labels.Add(text);
            }
            return Labels.ToArray();
        }
    }
    public class CustomAxis : Axis
    {
        public CustomAxis() : base(new CustomLabelProvider(), new TicksProvider())
        {
        }
    }
