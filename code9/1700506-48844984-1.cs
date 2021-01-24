    <TabControl x:Name="MyTabControl">
        <TabControl.Resources>
            <DataTemplate x:Key="MyTabContentTemplate" x:Shared="False">
                <local:GeckoBrowser Uri="{Binding Path=Uri}" />
            </DataTemplate>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="ContentTemplate" Value="{StaticResource MyTabContentTemplate}" />
            </Style>
        </TabControl.Resources>
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Path=Header}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
