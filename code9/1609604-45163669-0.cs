    <UserControl.Resources>
        <DataTemplate x:Key="tt" DataType="{x:Type test:ThumbDispData}">
            <TextBlock Text="{Binding AltText}"></TextBlock>
        </DataTemplate>
        <DataTemplate x:Key="img" DataType="{x:Type test:ThumbDispData}">
            <Image Source="{Binding Idhl}" />
        </DataTemplate>
        <local:Selector x:Key="selector" TextTemplate="{StaticResource tt}" ImageTemplate="{StaticResource img}" />
    </UserControl.Resources>
    <Grid Background="Transparent">
        <ItemsControl ItemsSource="{Binding}" ItemTemplateSelector="{StaticResource selector}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel IsItemsHost="True" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
    </Grid>
----------
    public class Selector : DataTemplateSelector
    {
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate TextTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ThumbDispData data = item as ThumbDispData;
            if (data != null && data.Idhl != null)
                return ImageTemplate;
            return TextTemplate;
        }
    }
