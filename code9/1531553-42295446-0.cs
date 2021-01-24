    public class RichTextBlockExtension
    {
        public static bool GetRemoveEmptyRuns(DependencyObject obj)
        {
            return (bool)obj.GetValue(RemoveEmptyRunsProperty);
        }
        public static void SetRemoveEmptyRuns(DependencyObject obj, bool value)
        {
            obj.SetValue(RemoveEmptyRunsProperty, value);
            if (value)
            {
                var tb = obj as RichTextBlock;
                if (tb != null)
                {
                    tb.Loaded += Tb_Loaded;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
        public static readonly DependencyProperty RemoveEmptyRunsProperty =
        DependencyProperty.RegisterAttached("RemoveEmptyRuns", typeof(bool),
        typeof(RichTextBlock), new PropertyMetadata(false));
        public static bool GetPreserveSpace(DependencyObject obj)
        {
            return (bool)obj.GetValue(PreserveSpaceProperty);
        }
        public static void SetPreserveSpace(DependencyObject obj, bool value)
        {
            obj.SetValue(PreserveSpaceProperty, value);
        }
        public static readonly DependencyProperty PreserveSpaceProperty =
        DependencyProperty.RegisterAttached("PreserveSpace", typeof(bool),
        typeof(Run), new PropertyMetadata(false));
        private static void Tb_Loaded(object sender, RoutedEventArgs e)
        {
            var tb = sender as RichTextBlock;
            tb.Loaded -= Tb_Loaded;
            foreach (var item in tb.Blocks)
            {
                Paragraph p = item as Paragraph;
                if(p!=null)
                {
                    var spaces = p.Inlines.Where(a => a is Run
                       && ((Run)a).Text == " "
                       && !GetPreserveSpace(a)).ToList();
                                spaces.ForEach(s => p.Inlines.Remove(s));
                }
            }
        }
    }
