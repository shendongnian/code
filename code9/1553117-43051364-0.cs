    public class SelectedCheckBoxBehaviour : System.Windows.Interactivity.Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
    
            AssociatedObject.MouseDown += AssociatedObject_MouseDown;
    
            base.OnAttached();
        }
    
        private void AssociatedObject_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement self = sender as FrameworkElement;
    
            if(self != null)
            {
                MyViewModel dataContext = self.DataContext as MyViewModel;
    
                dataContext.IsChecked = !dataContext.IsChecked;
            }
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.MouseDown -= AssociatedObject_MouseDown;
            base.OnDetaching();
        }
    }
