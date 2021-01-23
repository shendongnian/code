    public static class TextBlockExtension
    {
        public static string GetFormattedText(DependencyObject obj)
        { return (string)obj.GetValue(FormattedTextProperty); }
        public static void SetFormattedText(DependencyObject obj, string value)
        { obj.SetValue(FormattedTextProperty, value); }
        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.Register("FormattedText", typeof(string), typeof(TextBlockExtension),
            new PropertyMetadata(string.Empty, (sender, e) =>
            {
                string text = e.NewValue as string;
                var textBl = sender as TextBlock;
                if (textBl != null && !string.IsNullOrWhiteSpace(text))
                {
                    textBl.Inlines.Clear();
                    Regex regx = new Regex(@"(http(s)?://[\S]+|www.[\S]+|[\S]+@[\S]+)", RegexOptions.IgnoreCase);
                    Regex isWWW = new Regex(@"(http[s]?://[\S]+|www.[\S]+)");
                    Regex isEmail = new Regex(@"[\S]+@[\S]+");
                    foreach (var item in regx.Split(text))
                    {
                        if (isWWW.IsMatch(item))
                        {
                            Hyperlink link = new Hyperlink { NavigateUri = new Uri(item.ToLower().StartsWith("http") ? item : $"http://{item}"), Foreground = Application.Current.Resources["SystemControlForegroundAccentBrush"] as SolidColorBrush };
                            link.Inlines.Add(new Run { Text = item });
                            textBl.Inlines.Add(link);
                        }
                        else if (isEmail.IsMatch(item))
                        {
                            Hyperlink link = new Hyperlink { NavigateUri = new Uri($"mailto:{item}"), Foreground = Application.Current.Resources["SystemControlForegroundAccentBrush"] as SolidColorBrush };
                            link.Inlines.Add(new Run { Text = item });
                            textBl.Inlines.Add(link);
                        }
                        else textBl.Inlines.Add(new Run { Text = item });
                    }
                }
            }));
    }
