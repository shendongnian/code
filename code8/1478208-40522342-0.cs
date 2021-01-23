    rootPanel.Children.OfType<TextBox>().ToList()
                .ForEach(item =>
                {
                    if (item.Text.Contains("Reply"))
                    {
                        rootPanel.Children.Remove(item);
                    }
                });
