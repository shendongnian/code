    if ((bool)e.NewValue)
    {
        ItemsControl control = sender as ItemsControl;
        if (control != null)
        {
            control.UpdateLayout();
            Task task = Task.Run(delegate ()
                        {
                            while (control.ItemContainerGenerator.Status == GeneratorStatus.NotStarted ||
                                   control.ItemContainerGenerator.Status == GeneratorStatus.GeneratingContainers) ;
                        });
            if (await Task.WhenAny(task, Task.Delay(1000)) == task)
            {
                ContentPresenter first = control.ItemContainerGenerator.ContainerFromIndex(0) as ContentPresenter;
                if (first != null)
                {
                    if (first.IsLoaded)
                    {
                        (first.ContentTemplate.FindName("textBox", first) as System.Windows.UIElement).Focus();
                    }
                    else
                    {
                        RoutedEventHandler onload = null;
                        onload = delegate
                        {
                            first.Loaded -= onload;
                            (first.ContentTemplate.FindName("textBox", first) as System.Windows.UIElement).Focus();
                        };
                        first.Loaded += onload;
                    }
                }
            }
        }
    } 
