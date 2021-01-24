        public class OutlineCanvas : Canvas
        {
    
            public ProgressNoteOutline Outline
            {
                get { return (ProgressNoteOutline)GetValue(OutlineProperty); }
                set { SetValue(OutlineProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Outline.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty OutlineProperty =
                    DependencyProperty.Register("Outline", 
                    typeof(ProgressNoteOutline), typeof(OutlineCanvas),
                     new FrameworkPropertyMetadata(null, OnOutlineChanged));
    
            private static void OnOutlineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                OutlineCanvas canv = d as OutlineCanvas;
                if (canv == null)
                    return;           
    
                ProgressNoteOutline _outline = (ProgressNoteOutline)e.NewValue;
                if (_outline == null)
                    return;
    
                OutlineItem[] _items = _outline.items;
                if (_items == null)
                    return;
    
                foreach (OutlineItem t in _items)
                {
                    TextBlock tb = new TextBlock();
                    tb.Background = Brushes.AntiqueWhite;
                    tb.TextAlignment = TextAlignment.Left;
                    tb.Inlines.Add(new Italic(new Bold(new Run(t.text))));
    
                    SetLeft(tb, 0);
                    SetTop(tb, t.Y);
    
                    canv.Children.Add(tb);
                }
            }
        }
    
