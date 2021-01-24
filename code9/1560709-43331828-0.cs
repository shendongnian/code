    //MyDataTemplateSelector.cs
    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ImageTemplate { get; set; }
     
        protected override DataTemplate SelectTemplateCore(object item, 
                                                           DependencyObject container)
        {
            //Here you can cast 'item' and check the RealTime value
            if (item is TextItem)
                return TextTemplate;
            if (item is ImageItem)
                return ImageTemplate;
     
            return base.SelectTemplateCore(item, container);
        }
    }
    //XAML
    <Page.Resources>
        <DataTemplate x:Key="TextDataTemplate">
            <Border BorderBrush="LightGray" BorderThickness="1">
                <Grid HorizontalAlignment="Left" Width="400" Height="280">
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" Margin="15,0,15,20"
                                   Style="{StaticResource TitleTextStyle}"
                            TextWrapping="Wrap" TextTrimming="WordEllipsis" MaxHeight="40"/>
                        <TextBlock Text="{Binding Content}" Margin="15,0,15,0" Height="200"
                            TextWrapping="Wrap" TextTrimming="WordEllipsis"/>
                    </StackPanel>
                </Grid>
            </Border>
        </DataTemplate>
     
        <DataTemplate x:Key="ImageDataTemplate">
            <Grid HorizontalAlignment="Left" Width="400" Height="280">
                <Border Background=
                        "{StaticResource ListViewItemPlaceholderBackgroundThemeBrush}">
                    <Image Source="{Binding Url}" Stretch="UniformToFill"/>
                </Border>
                <StackPanel VerticalAlignment="Bottom"
                            Background=
                            "{StaticResource ListViewItemOverlayBackgroundThemeBrush}">
                    <TextBlock Text="{Binding Name}"
                               Foreground=
                               "{StaticResource ListViewItemOverlayForegroundThemeBrush}"
                               Style="{StaticResource TitleTextStyle}"
                               Height="40" Margin="15,0,15,0"/>
                </StackPanel>
            </Grid>
        </DataTemplate>
     
        <local:MyDataTemplateSelector x:Key="MyDataTemplateSelector"
            TextTemplate="{StaticResource TextDataTemplate}"
            ImageTemplate="{StaticResource ImageDataTemplate}">
        </local:MyDataTemplateSelector>
    </Page.Resources>
    
    <GridView
        x:Name="itemGridView"
        Padding="116,137,40,46"      
        ItemTemplateSelector="{StaticResource MyDataTemplateSelector}" />
