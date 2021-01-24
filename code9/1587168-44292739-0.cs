    You can do it this way. Below is a sample Xaml
    
    <Grid>
        <StackPanel Orientation="Vertical">
            <TextBlock>Outside area of frame</TextBlock>
            <Frame Name="FrameWithinGrid"  Source="{Binding FrameSource}">
            </Frame>
            <Button x:Name="button1" Height="23" Margin="114,12,25,0" Command="{Binding GoToCommand}"   
                VerticalAlignment="Top" >Navigate to Msdn
            </Button>
        </StackPanel>
    
    
    </Grid>
    
    In Your ViewModel , some sample codes for example
          private Uri _frameSource = new Uri("http://www.google.com", UriKind.Absolute);
          public Uri FrameSource
          {
             get { return _frameSource;}
    
             set
             {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
             }
          }
    
          public ICommand GoToCommand
          {
             get
             {
                return new DelegateCommand(ExecuteGoTo);
             }
          }
    
          private void ExecuteGoTo()
          {
             FrameSource = new Uri("http://www.msdn.com", UriKind.Absolute);
          }
        enter code here
    
    Thats all. Make sure your view model implements INotifyPropertyChanged. If you are using MVVM Light, change the DelegateCommand to RelayCommand
