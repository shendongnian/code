    <MenuItem x:Name="MyMenu" Header="MENU">
        <MenuItem.Style>
            <Style TargetType="MenuItem">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Items.Count}" Value="0">
                        <Setter Property="IsEnabled" Value="False" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </MenuItem.Style>
    </MenuItem>
