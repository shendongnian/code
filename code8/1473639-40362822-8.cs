    <ResourceDictionary 
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:HeaderedPopupTest.Themes"
        xmlns:hec="clr-namespace:HollowEarth.Controls"
        >
        <ResourceDictionary.MergedDictionaries>
            <!-- Change HeaderedPopupTest to the name of your own assembly -->
            <ResourceDictionary Source="/HeaderedPopupTest;component/Themes/Shared.xaml" />
        </ResourceDictionary.MergedDictionaries>
        <Style TargetType="hec:IconPopupButton">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="hec:IconPopupButton">
                        <Grid x:Name="Grid">
                            <ToggleButton
                                x:Name="OpenButton"
                                Style="{StaticResource btnIcons}"
                                Background="{TemplateBinding IconFill}"
                                Tag="{TemplateBinding IconData}"
                                IsChecked="{Binding IsOpen, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                                ToolTip="{TemplateBinding ToolTip}"
                                />
                            <Popup
                                x:Name="Popup"
                                StaysOpen="{Binding StaysOpen, RelativeSource={RelativeSource TemplatedParent}}"
                                IsOpen="{Binding IsOpen, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                                PlacementTarget="{Binding ElementName=ToggleButton}"
                                Placement="{TemplateBinding Placement}"
                                >
                                <Border 
                                    Background="Green"
                                    CornerRadius="3"
                                    Padding="10,0,12,10">
                                    <StackPanel>
                                        <ToggleButton 
                                            HorizontalAlignment="Right" 
                                            Tag="{StaticResource ic_gclear}"
                                            Style="{StaticResource btnIcons}"
                                            Background="White"
                                            Margin="10,5,12,5"
                                            IsChecked="{Binding IsOpen, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                                            Height="24" 
                                            />
                                        <ContentPresenter 
                                            x:Name="content"
                                            TextBlock.FontSize="14"
                                            TextBlock.Foreground="White"
                                            TextBlock.FontFamily="Arial"
                                            Content="{TemplateBinding Content}"
                                            />
                                    </StackPanel>
                                </Border>
                            </Popup>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <!-- 
                                    I don't understand this: If I use the templated parent's IsOpen, 
                                    the effect is as if it were never true. 
                                    -->
                                    <Condition SourceName="Popup" Property="IsOpen" Value="True" />
                                    <Condition Property="StaysOpen" Value="False" />
                                </MultiTrigger.Conditions>
                                <!-- 
                                If StaysOpen is false and the button is enabled while the popup is open, 
                                then clicking on it will cause the popup to flicker rather than close. 
                                -->
                                <Setter TargetName="OpenButton" Property="IsEnabled" Value="False" />
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
