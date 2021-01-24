    public partial class MainWindow : Window
    {
        public double MyFontSize { get; set; } = 30;
        public MainWindow()
        {
            InitializeComponent();
        }
    }
----------
    <Window.Resources>
        <Style TargetType="{x:Type DataGridColumnHeader}">
            <Setter Property="Background" Value="#0091EA"/>
            <Setter Property="Opacity" Value="1"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="HorizontalContentAlignment" Value="Center" />
            <Setter Property="FontSize" Value="{Binding MyFontSize, RelativeSource={RelativeSource AncestorType=Window}}"/>
            <Setter Property="FontFamily" Value="Arial"/>
            <Setter Property="Height" Value="40"/>
        </Style
    </Window.Resources>
