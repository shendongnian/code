    <UserControl>
    <UserControl.Resources>     
        <Style x:Key="ImageEnabled" TargetType="Image">
            <Style.Triggers>
                <Trigger Property="IsEnabled" Value="False">
                    <Setter Property="Opacity" Value="0.25"></Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
    <Button  Name="button" Width="256" Height="79" Click="button_Click_1" FontSize="20" FontWeight="Bold">
          <Image Source="{StaticResource NormalImage}" Style="{StaticResource ImageEnabled}"/>
        <Button.Template> 
    
    <ControlTemplate TargetType="{x:Type Button}">
                            <Border Name="buttonBorder">
                                <Border.Effect>
                                    <DropShadowEffect Opacity="0.0" />
                                </Border.Effect>
                                <ContentPresenter x:Name="contentPresenter" Focusable="False" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="true">
                                    <Setter TargetName="buttonBorder" Property="Effect">
                                        <Setter.Value>
                                            <DropShadowEffect Opacity="0.0" />
                                        </Setter.Value>
                                    </Setter>
    
                                </Trigger>
                                <Trigger Property="IsMouseCaptured" Value="true">
                                    <Setter TargetName="buttonBorder" Property="Effect">
                                        <Setter.Value>
                                            <DropShadowEffect Opacity="0" Direction="135"  
                             ShadowDepth="0" BlurRadius="0" />
                                        </Setter.Value>
                                    </Setter>
                                </Trigger>
                                <Trigger Property="IsPressed" Value="true">
                                    <Setter TargetName="buttonBorder" Property="Effect">
                                        <Setter.Value>
                                            <DropShadowEffect Opacity="0.0"/>
                                        </Setter.Value>
                                    </Setter>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
     </Button.template>
    </Button>
    </UserControl>
