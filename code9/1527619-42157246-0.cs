    public class MainWindowViewModel : DependencyObject
    {
        public static readonly DependencyProperty KeyFieldVMProperty =
            DependencyProperty.Register("KeyFieldVM", typeof(string),
                typeof(MainWindowViewModel), new FrameworkPropertyMetadata("ok"));
        public string KeyFieldVM
        {
            get { return (string)GetValue(KeyFieldVMProperty); }
            set { SetValue(KeyFieldVMProperty, value); }
        }
    }
----------
    <Window ... x:Name="win">
        <Window.DataContext>
            <vm:MainWindowViewModel KeyFieldVM="{Binding KeyFieldView, ElementName=win}"/>
        </Window.DataContext>
        <Grid>
            <TextBlock Text="{Binding KeyFieldVM}" />
        </Grid>
    </Window>
