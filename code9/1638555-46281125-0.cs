    <ContextMenu>
        <ContextMenu.Resources>
            <CollectionViewSource x:Key="ContextMenuColCollection" Source="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path= DataContext.HeaderContextMenu}"/>
            <DataTemplate DataType="{x:Type vm:Collection1VM}" >
                <TextBlock Text="{Binding Name}"/>
            </DataTemplate>
            <local:Converter x:Key="conv" />
        </ContextMenu.Resources>
        <ContextMenu.ItemsSource>
            <CompositeCollection>
                <MenuItem Header="Settings"/>
                <Separator />
                <CollectionContainer Collection="{Binding Source={StaticResource ContextMenuColCollection}}"/>
            </CompositeCollection>
        </ContextMenu.ItemsSource>
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}">
                <Setter Property="IsCheckable" Value="True"/>
                <Setter Property="IsChecked" Value="{Binding Path=., Converter={StaticResource conv}}"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
