        private void UserControl_IsVisibleChanged(object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
                return;
            if (DataContext is CameraViewModel)
            {
                SaveTransform();
            }
            else Dispatcher.InvokeAsync(SaveTransform);
        }
        private void SaveTransform()
        {
            var vm = DataContext as CameraViewModel;
            var w = VisualTreeHelper.GetParent(this) as FrameworkElement;
            while (w != null && !(w is Window))
                w = VisualTreeHelper.GetParent(w) as FrameworkElement;
            if (w != null)
            {
                vm.GetTransform = () => TransformToAncestor(w);
            }
        }
