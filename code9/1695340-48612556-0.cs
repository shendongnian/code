    <Button>
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <Style.Setters>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type Button}">
                                <Border Width="{TemplateBinding Width}" Height="{TemplateBinding Height}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}">
                                    <ContentPresenter />
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Trigger.Setters>
                                            <Setter Property="Background" Value="Black" />
                                        </Trigger.Setters>
                                    </Trigger>
                                    <Trigger Property="IsMouseOver" Value="False">
                                        <Trigger.Setters>
                                            <Setter Property="Background">
                                                <Setter.Value>
                                                    <ImageBrush ImageSource="/Images/close.ico"/>
                                                </Setter.Value>
                                            </Setter>
                                        </Trigger.Setters>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style.Setters>
            </Style>
        </Button.Style>
    </Button>
