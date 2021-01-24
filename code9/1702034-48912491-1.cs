    public class HamburgerButton : Button
    {
        public HamburgerButton()
        {
            // Default Font Height of Button
            double H = (double)Button.FontSizeProperty.GetMetadata(typeof(double)).DefaultValue;
            double A = H / 5;
            GeometryCollection DataHamburger = new GeometryCollection
            {
                new RectangleGeometry {Rect = new Rect{X = 0, Y = 0*A,  Width = 20, Height = A/2 }},
                new RectangleGeometry {Rect = new Rect{X = 0, Y = 2*A,  Width = 20, Height = A/2 }},
                new RectangleGeometry {Rect = new Rect{X = 0, Y = 4*A,  Width = 20, Height = A/2 }},
            };
            Path PathHamburger = new Path
            {
                Fill    = new SolidColorBrush(Colors.DarkGray),
                Stroke  = new SolidColorBrush(Colors.DarkGray),
                StrokeThickness = 1.0,
                Height  = H,
                Margin = new Thickness(4.5), // <==??? HOW TO AUTOMATICALLY CALCULATE??
                Data = new GeometryGroup { Children = DataHamburger }
            };
            Content = PathHamburger;
        }
    }
     <!-- This XAML demonstrates the button heights don't have
          the same height despite setting the Vector Path
          height to 11 pixels, the same as the Text of String based Button-->
     <Page
        x:Class="GridNineExperiment.BlankPage1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:GridNineExperiment"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
    
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
    
            <local:Button1  Grid.Column="0" Grid.Row="0" Content="Hello"/>
            <local:HamburgerButton  Grid.Column="1" Grid.Row="0"/>
        </Grid>
    </Page>
