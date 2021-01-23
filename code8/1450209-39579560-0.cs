    <Style TargetType="Button">
        <Style.Triggers>
            <Trigger Property="Tag" Value="MenuButton">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <Border BorderThickness="1,0,0,1" Background="{TemplateBinding Background}">
                                <ContentPresenter
                                    x:Name="ContentPresenter"
                                    Margin="1"
                                    VerticalAlignment="Center"
                                    HorizontalAlignment="Center"
                                    Opacity="1.0"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsEnabled" Value="False">
                                    <Setter Property="Background" Value="{StaticResource DisabledBackgroundBrush}"/>
                                    <Setter TargetName="ContentPresenter" Property="Opacity" Value="0.5"/>
                                </Trigger>
                                <Trigger Property="IsEnabled" Value="True">
                                    <Setter Property="Background" Value="{StaticResource BackgroundBrush}"/>
                                    <Setter TargetName="ContentPresenter" Property="Opacity" Value="1"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers>
    </Style>
