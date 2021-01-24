     public class SearchHightlightTextBlock : TextBlock
    {
        public SearchHightlightTextBlock() : base() { }
    
        public String SearchText
        {
            get { return (String)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }
    
        private static void OnDataChanged(DependencyObject source,
            DependencyPropertyChangedEventArgs e)
        {
            TextBlock tb = (TextBlock)source;
    
            if (tb.Text.Length == 0)
                return;
    
            string textUpper = tb.Text.ToUpper();
            String toFind = ((String)e.NewValue).ToUpper();
            int firstIndex = textUpper.IndexOf(toFind);
            String firstStr = "";
            String foundStr = "";
            if (firstIndex != -1)
            {
                firstStr = tb.Text.Substring(0, firstIndex);
                foundStr = tb.Text.Substring(firstIndex, toFind.Length);
            }
            String endStr = tb.Text.Substring(firstIndex + toFind.Length,
                tb.Text.Length - (firstIndex + toFind.Length));
    
            tb.Inlines.Clear();
            tb.FontSize = 16;
            var run = new Run();
            run.Text = firstStr;
            tb.Inlines.Add(run);
            run = new Run();
            run.Background = Brushes.Yellow;
            run.Text = foundStr;
            tb.Inlines.Add(run);
            run = new Run();
            run.Text = endStr;
    
            tb.Inlines.Add(run);
        }
    
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText",
                typeof(String),
                typeof(SearchHightlightTextBlock),
                new FrameworkPropertyMetadata(null, OnDataChanged));
    }
