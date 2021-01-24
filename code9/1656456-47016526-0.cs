    public class SelectedChangedTrigger : TriggerAction<ListView>
    {
        protected override void Invoke(ListView sender)
        {
            var selectedItem = sender.SelectedItem as Item;
            var viewModel = selectedItem?.BindingContext as ViewModelType;
            viewModel.PerformAction(); //<-- your view-model's method or property to update/invoke 
        }
    }
