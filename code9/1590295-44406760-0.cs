    <!-- default checked and over color -->
    <SolidColorBrush x:Key="TgCheckedAndOver" Color="DarkBlue" />
    <!-- default checked color -->
    <SolidColorBrush x:Key="TgChecked" Color="SkyBlue" />
    <Style 
           TargetType="{x:Type ToggleButton}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ToggleButton">
                    <Border Padding="18,12,18,12"
                            Background="{TemplateBinding Background}">
                        <ContentPresenter />
                    </Border>
                    <ControlTemplate.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsChecked"
                                           Value="True" />
                                <Condition Property="IsMouseOver"
                                           Value="True" />
                            </MultiTrigger.Conditions>
                            <MultiTrigger.Setters>
                                <Setter Property="Background"
                                        Value="{DynamicResource TgCheckedAndOver}" />
                            </MultiTrigger.Setters>
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsChecked"
                                           Value="True" />
                                <Condition Property="IsMouseOver"
                                           Value="False" />
                            </MultiTrigger.Conditions>
                            <MultiTrigger.Setters>
                                <Setter Property="Background"
                                        Value="{DynamicResource TgChecked}" />
                            </MultiTrigger.Setters>
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsChecked"
                                           Value="False" />
                                <Condition Property="IsMouseOver"
                                           Value="False" />
                            </MultiTrigger.Conditions>
                            <MultiTrigger.Setters>
                                <Setter Property="Background"
                                        Value="#88000000" />
                            </MultiTrigger.Setters>
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsChecked"
                                           Value="False" />
                                <Condition Property="IsMouseOver"
                                           Value="True" />
                            </MultiTrigger.Conditions>
                            <MultiTrigger.Setters>
                                <Setter Property="Background"
                                        Value="#F0000000" />
                            </MultiTrigger.Setters>
                        </MultiTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
