        private void StackPanel_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var values = new List<string>();
            var sp = sender as StackPanel;
            if (sp != null)
            {
                foreach (var child in sp.Children)
                {
                    var tb = child as TextBlock;
                    if (tb != null)
                    {
                        values.Add(tb.Text);
                    }
                }
            }
        }
