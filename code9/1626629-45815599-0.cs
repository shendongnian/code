    <Style TargetType="DataGridCell">
        <Setter Property="Foreground" Value="Pink" />
        <Style.Triggers>
            <DataTrigger Value="false">
                <DataTrigger.Binding>
                    <MultiBinding Converter="{StaticResource multiConverter}">
                        <Binding Path="Changed" />
                        <Binding Path="." RelativeSource="{RelativeSource Self}" />
                    </MultiBinding>
                </DataTrigger.Binding>
                <Setter Property="Foreground" Value="Lime" />
            </DataTrigger>
        </Style.Triggers>
        <Setter Property="ContextMenu" Value="{StaticResource CellContextMenu}" />
    </Style>
----------
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        DataGridCell dgc = values[1] as DataGridCell;
        if (dgc != null)
        {
            ENTRY entry = dgc.DataContext as _ENTRY;
            if (entry != null)
            {
                DataGridTextColumn column = dgc.Column as DataGridTextColumn;
                if (column != null)
                {
                    var binding = column.Binding as Binding;
                    if (binding != null && binding.Path != null && binding.Path.Path != null)
                    {
                        string val = binding.Path.Path.ToLower();
                        if (val.StartsWith("monday"))
                        {
                            return entry.monday.Changed;
                        }
                        if (val.StartsWith("tuesday"))
                        {
                            return entry.tuesday.Changed;
                        }
                        if (val.StartsWith("wednesday"))
                        {
                            return entry.wednesday.Changed;
                        }
                        if (val.StartsWith("thursday"))
                        {
                            return entry.thursday.Changed;
                        }
                        if (val.StartsWith("friday"))
                        {
                            return entry.friday.Changed;
                        }
                        if (val.StartsWith("saturday"))
                        {
                            return entry.saturday.Changed;
                        }
                        if (val.StartsWith("sunday"))
                        {
                            return entry.sunday.Changed;
                        }
                    }
                }
            }
        }
        return false;
    }
