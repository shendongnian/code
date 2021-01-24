    public partial class MainViewModel
    {
        public DelegateCommand ToggleLayersCommand { get; private set; }
    
        public MainViewModel()
        {
            ToggleLayersCommand = new DelegateCommand(ToggleLayersCommand_OnExecuted, () => true);
        }
    
        private void ToggleLayersCommand_OnExecuted()
        {
            LayerListPanel.Visibility = (LayerListPanel.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed; 
    //THIS WILL PROBABLY NOT WORK...
    //You can use another public property to change your visibility.
    // Create a public visibility and bind it to the correct item
        }
     }
