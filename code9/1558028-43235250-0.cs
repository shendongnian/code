        public double calculateWidth (string text)
        {
            Rect bounds = new Rect();
            TextView textView = new TextView(Forms.Context);
            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);
            var length = bounds.Width();           
            return length / Resources.System.DisplayMetrics.ScaledDensity;
        }
