    <Grid>
        <Grid.Resources>
            <SolidColorBrush x:Key="TextBox.Static.Border" Color="#FFABAdB3"/>
            <SolidColorBrush x:Key="TextBox.MouseOver.Border" Color="#FF7EB4EA"/>
            <SolidColorBrush x:Key="TextBox.Focus.Border" Color="#FF569DE5"/>
            <Style TargetType="TextBox" BasedOn="{StaticResource {x:Type TextBox}}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TextBox}">
                            <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{TemplateBinding Background}"
                                    SnapsToDevicePixels="True">
                                <ScrollViewer x:Name="PART_ContentHost" Focusable="false"
                                          HorizontalScrollBarVisibility="Hidden"
                                          VerticalScrollBarVisibility="Hidden"
                                          VerticalAlignment="Center"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsEnabled" Value="false">
                                    <Setter Property="Opacity" TargetName="border" Value="0.56"/>
                                </Trigger>
                                <Trigger Property="IsMouseOver" Value="true">
                                    <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.MouseOver.Border}"/>
                                </Trigger>
                                <Trigger Property="IsKeyboardFocused" Value="true">
                                    <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.Focus.Border}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        ...
        <TextBox Height="100" Text="Centered text..." />
    </Grid>
