    <Style x:Key="CellStyle" TargetType="{x:Type DataGridCell}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding Column.DisplayIndex, RelativeSource={RelativeSource Self}}" Value="0">
                <Setter Property="IsEnabled" 
                        Value="{Binding 
                                Path=Item,
                                Converter={StaticResource ResourceKey=IsEnabledCellConverter}, 
                                ConverterParameter=0,
                                RelativeSource={RelativeSource AncestorType={x:Type DataGridRow}}}" />
            </DataTrigger>
            <DataTrigger Binding="{Binding Column.DisplayIndex, RelativeSource={RelativeSource Self}}" Value="1">
                <Setter Property="IsEnabled" 
                        Value="{Binding 
                                Path=Item,
                                Converter={StaticResource ResourceKey=IsEnabledCellConverter}, 
                                ConverterParameter=1,
                                RelativeSource={RelativeSource AncestorType={x:Type DataGridRow}}}" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
