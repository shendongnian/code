    class Template1 : Grid
    {
        public Template1()
        {
            Background = Brushes.White;
            Children.Add(
                new AdornerDecorator()
                {
                    Child = new StackPanel
                    {
                        Children =
                        {
                            new TextBox(),
                            new Button() { Content = "button 1" },
                            new Button() { Content = "button 2" },
                        }
                    }
                }
            );
        }
    }
