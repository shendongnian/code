                    public TextBlockCodeBehindSample()
                {
                        InitializeComponent();
                        TextBlock tb = new TextBlock();
                        tb.TextWrapping = TextWrapping.Wrap;
                        tb.Margin = new Thickness(10);
                        tb.Inlines.Add("An example on ");
                        tb.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
                        tb.Inlines.Add("using ");
                        tb.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });
                        tb.Inlines.Add(new Run("text formatting ") { Foreground = Brushes.Blue });
                        tb.Inlines.Add("from ");
                        tb.Inlines.Add(new Run("Code-Behind") { TextDecorations = TextDecorations.Underline });
                        tb.Inlines.Add(".");
                        this.Content = tb;
                }
