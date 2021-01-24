    public partial class MainViewModel
    {
        public DelegateCommand ToggleLayersCommand { get; private set; }
    
        public MainViewModel()
        {
            ToggleLayersCommand = new DelegateCommand(ToggleLayersCommand_OnExecuted, () => true);
        }
    
        private void ToggleLayersCommand_OnExecuted()
        {
            LayerListPanel.Visibility = (LayerListPanel.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed; //THIS WILL PROBABLY NOT WORK...
        }
     }
    <Menu>
            <MenuItem Header="View" Padding="5, 2">
                <MenuItem Header="Toggle Layers Panel" InputGestureText="CTRL + L" Command="{Binding Path=ToggleLayersCommand}" />
            </MenuItem>
        </Menu>
