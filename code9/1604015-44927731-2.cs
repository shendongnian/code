    public string ResourceString
    {
        get => (string)GetValue(ResourceStringProperty);
        set => SetValue(ResourceStringProperty, value);
    }
    public static readonly DependencyProperty ResourceStringProperty = DependencyProperty.Register(
        "ResourceString", typeof(string), typeof(TextControl), new PropertyMetadata(default(string), (s, e) =>
        {
            var self = (TextControl)s;
            var full = e.NewValue.ToString();
            foreach (var seg in full.Split(' '))
            {
                var run = new Run();
                if (seg.Contains("{0}"))
                {
                    run.Text = self.Input0;
                    run.FontWeight = FontWeights.Bold;
                }
                else if (seg.Contains("{1}"))
                {
                    run.Text = self.Input1;
                    run.FontWeight = FontWeights.Bold;
                }
                else
                {
                    run.Text = seg;
                }
                run.Text += " ";
                self.MyTextBlock.Inlines.Add(run);
            }
        }));
    public string Input0
    {
        get => (string)GetValue(Input0Property);
        set => SetValue(Input0Property, value);
    }
    public static readonly DependencyProperty Input0Property = DependencyProperty.Register(
        "Input0", typeof(string), typeof(TextControl), new PropertyMetadata(default(string)));
    public string Input1
    {
        get => (string)GetValue(Input1Property);
        set => SetValue(Input1Property, value);
    }
    public static readonly DependencyProperty Input1Property = DependencyProperty.Register(
        "Input1", typeof(string), typeof(TextControl), new PropertyMetadata(default(string)));
