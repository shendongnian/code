                public class MainWindowViewModel        
                {
                    private string _customeName;
            
                    public string CustomerName
                    {
                        get { return _customeName; }
                        set { _customeName = value; }
                    }
            
            
                }
            
                public partial class MainWindow : Window
                {
                    public string CustomerName { get; set; }
            
            
                    public MainWindow()
                    {
                        InitializeComponent();
                        this.DataContext = new MainWindowViewModel();
                    }
                }
            }
    
    <UserControl x:Class="SampleApp.ControlDesigner"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 xmlns:local="clr-namespace:SampleApp"
                 mc:Ignorable="d" 
                 d:DesignHeight="100" d:DesignWidth="300">
        <Grid>
            <TextBlock Text="{Binding CustomerName}"></TextBlock>   
        </Grid>
    </UserControl>
