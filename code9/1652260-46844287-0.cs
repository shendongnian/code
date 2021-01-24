    <ContentControl Name="CustomControlContent" HorizontalContentAlignment="Stretch" VerticalContentAlignment="Stretch">
        <ContentControl.Style>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <Trigger Property="IsEnabled" Value="False">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="ContentControl">
                                    <Grid HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
                                        <ContentPresenter 
                                        Content="{TemplateBinding Content}"
                                        ContentTemplate="{TemplateBinding ContentTemplate}"
                                        Cursor="{TemplateBinding Cursor}"
                                        Margin="{TemplateBinding Padding}"
                                        HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                        VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                        Opacity="0.6">
                                            <ContentPresenter.Effect>
                                                <BlurEffect Radius="5"/>
                                            </ContentPresenter.Effect>
                                        </ContentPresenter>
                                        <TextBlock Text="Update, please wait ..." HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
        <ContentControl.Content>
            <Image Source="C:\Users\Public\Pictures\Sample Pictures\Jellyfish.jpg"/>
        </ContentControl.Content>
    </ContentControl>
