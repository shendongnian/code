        <Style TargetType="{x:Type views:BaseView}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type views:BaseView}">
                        <Border CornerRadius="5"  BorderThickness="2">
                            <Grid Name="RootGrid">
                                <ContentPresenter></ContentPresenter>
                            </Grid>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
