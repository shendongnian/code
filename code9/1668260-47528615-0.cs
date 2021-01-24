    public static class GradientGenerator
    {
        public static Brush GenerateTwoColorBrush(Color color1, Color color2, double ratio)
        {
            GradientStopCollection collection = new GradientStopCollection();
            collection.Add(new GradientStop(color1, 0));
            collection.Add(new GradientStop(color1, ratio));
            collection.Add(new GradientStop(color2, ratio));
            collection.Add(new GradientStop(color2, 1.0));
            LinearGradientBrush brush = new LinearGradientBrush(collection);
            return brush;
        }
    }
