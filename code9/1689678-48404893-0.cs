        <Grid>
           <Label x:Name="ProgressMessage" Background="LightSteelBlue" Height="28" Margin="19,0,17,15" VerticalAlignment="Bottom"
               Foreground="White" ></Label>
    
        </Grid>
        public partial class Splash : Window
        {
            public Splash()
            {
                InitializeComponent();
            }
            async public Task ReceiveMessageAsync(string message)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    ProgressMessage.Content = message;
                });
            }
            public void ReceiveMessage(string message)
            {
                ProgressMessage.Content = message;
            
            }
        }
