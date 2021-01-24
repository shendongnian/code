    <Style x:Key="TransparentStyle" TargetType="{x:Type Button}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border>
                        <Border.Style>
                            <Style TargetType="{x:Type Border}">
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="Background">
                                         <Setter.Value>
                                          <ImageBrush ImageSource= "\Images\ButtonImages\Image.png" Stretch="Uniform"/>
                                         </Setter.Value> 
                                       </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </Border.Style>
                        <Grid Background="Transparent">
                            <ContentPresenter></ContentPresenter>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
