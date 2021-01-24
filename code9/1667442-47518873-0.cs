       Content = new StackLayout
        {
            Margin = new Thickness(20),
            Children = {
                new ListView {
                    HasUnevenRows = true,
                    ItemsSource = _model.Data,
                    ItemTemplate = AnlDataTemplate,
                    Margin = new Thickness(0, 20, 0, 0)
                }
            }
        };
