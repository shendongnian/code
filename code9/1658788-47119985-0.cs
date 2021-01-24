    <Button Content="Hello">
        <Button.Style>
            <Style TargetType="Button">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <Border Background="{TemplateBinding Background}"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                <ContentPresenter
                                    HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                    VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="Images/StandardBackground.png"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Background">
                            <Setter.Value>
                                <ImageBrush ImageSource="Images/MouseOverBackground.png"/>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
