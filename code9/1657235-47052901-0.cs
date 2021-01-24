    <SolidColorBrush x:Key="MenuItem.Highlight.Background" Color="#3D26A0DA"/>
    <SolidColorBrush x:Key="MenuItem.Highlight.Border" Color="#FF26A0DA"/>
    <SolidColorBrush x:Key="Menu.Disabled.Foreground" Color="#FF707070"/>
    <Style x:Key="MenuItemToggleStyle" TargetType="{x:Type MenuItem}" BasedOn="{StaticResource {x:Type MenuItem}}">
        <Style.Triggers>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsChecked" Value="True"/>
                    <Condition Property="IsCheckable" Value="True"/>
                    <Condition Property="Role" Value="TopLevelItem"/>
                </MultiTrigger.Conditions>
                <MultiTrigger.Setters>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="MenuItem">
                                <Border x:Name="templateRoot" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="true">
                                    <Grid VerticalAlignment="Center">
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto"/>
                                            <ColumnDefinition Width="Auto"/>
                                        </Grid.ColumnDefinitions>
                                        <ContentPresenter x:Name="Icon" ContentSource="Icon" HorizontalAlignment="Center" Height="16" Margin="3" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="Center" Width="16"/>
                                        <ContentPresenter Grid.Column="1" ContentSource="Header" Margin="{TemplateBinding Padding}" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                    </Grid>
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="Icon" Value="{x:Null}">
                                        <Setter Property="Visibility" TargetName="Icon" Value="Collapsed"/>
                                    </Trigger>
                                    <Trigger Property="IsEnabled" Value="False">
                                        <Setter Property="TextElement.Foreground" TargetName="templateRoot" Value="{StaticResource Menu.Disabled.Foreground}"/>
                                        <Setter Property="BorderBrush" TargetName="templateRoot" Value="{StaticResource MenuItem.Highlight.Border}"/>
                                    </Trigger>
                                    <Trigger Property="IsEnabled" Value="True">
                                        <Setter Property="Background" TargetName="templateRoot" Value="{StaticResource MenuItem.Highlight.Background}"/>
                                        <Setter Property="BorderBrush" TargetName="templateRoot" Value="{StaticResource MenuItem.Highlight.Border}"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </MultiTrigger.Setters>
            </MultiTrigger>
        </Style.Triggers>
    </Style>
