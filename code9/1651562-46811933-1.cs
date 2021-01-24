    <ItemsControl ItemsSource="{Binding Shapes}">
        <ItemsControl.Resources>
            <SolidColorBrush x:Key="NormalBrush" Color="AliceBlue"/>
            <SolidColorBrush x:Key="MouseOverBrush" Color="Red"/>
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Path Data="{Binding}">
                    <Path.Style>
                        <Style TargetType="Path">
                            <Setter Property="Fill" Value="{StaticResource NormalBrush}"/>
                            <Style.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="Fill"
                                            Value="{StaticResource MouseOverBrush}"/>
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </Path.Style>
                </Path>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
