    <TabControl x:Name="tabContainer">
        <TabControl.Resources>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="Header" Value="{Binding TabHeader}" />
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="{Binding}" />
                                <Button Content="x" Click="Button_Click_2"
                                                Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=TabItem}}"/>
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TabControl.Resources>
    </TabControl>
