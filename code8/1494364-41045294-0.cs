    public class MainWindowViewModel : BindableBase
    {
    ...
       public Boolean RunTinting2
      {
        get { return this.model.RunTinting; }
        set { this.model.RunTinting = value; OnPropertyChanged("RunTinting2"); }
      }
    }
    <Label x:Name="label1_Copy11" Content="{Binding RunTinting2}" HorizontalAlignment="Left" Margin="366,320,0,0" VerticalAlignment="Top" Height="25" Width="85" >
