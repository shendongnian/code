    <Style x:Key="ContextMenuStyle1" TargetType="{x:Type ContextMenu}">
        <Setter Property="OverridesDefaultStyle" Value="True"/>
        <Setter Property="Background" Value="{DynamicResource MenuPopupBackgroundBrush}"/>
        <Setter Property="BorderThickness" Value="1"/>
        <Setter Property="BorderBrush" Value="{DynamicResource MenuPopupBorderBrush}"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Padding" Value="2"/>
        <Setter Property="Grid.IsSharedSizeScope" Value="True"/>
        <Setter Property="HasDropShadow" Value="{DynamicResource {x:Static SystemParameters.DropShadowKey}}"/>
        <Setter Property="ScrollViewer.PanningMode" Value="Both"/>
        <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
        <Setter Property="FontFamily" Value="{DynamicResource {x:Static SystemFonts.MessageFontFamilyKey}}"/>
        <Setter Property="FontSize" Value="{DynamicResource {x:Static SystemFonts.MessageFontSizeKey}}"/>
        <Setter Property="FontWeight" Value="{DynamicResource {x:Static SystemFonts.MessageFontWeightKey}}"/>
    </Style>
    <Button>
        <Button.ContextMenu>
            <ContextMenu x:Name="cm1" Style="{DynamicResource ContextMenuStyle1}" >
                <MenuItem Header="Item 1"></MenuItem>
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
