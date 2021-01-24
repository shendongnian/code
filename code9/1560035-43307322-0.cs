    <MenuItem Header="Save File" Command="{Binding ActiveDocument.SaveCommand}">
        <MenuItem.Style>
            <Style TargetType="MenuItem">
                <Style.Triggers>
                    <Trigger Property="Command" Value="{x:Null}">
                        <Setter Property="IsEnabled" Value="False" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </MenuItem.Style>
    </MenuItem>
