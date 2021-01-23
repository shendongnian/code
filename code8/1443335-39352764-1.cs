     <MenuItem x:Name="systemMenuItem" Header="System">
        <MenuItem.Visibility>
            <MultiBinding Converter="{StaticResource ElementPermissionToVisibilityConverter}">
                <Binding Path="Permissions"/>
                <Binding RelativeSource="{RelativeSource Self}"/>
            </MultiBinding>
        </MenuItem.Visibility>
    </MenuItem>
