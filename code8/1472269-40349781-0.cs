    <Style TargetType="TabItem">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type TabItem}">
                    <Border>
                        <ContentPresenter ContentSource="Header">
                            <ContentPresenter.ContentTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{TemplateBinding Content}" />
                                </DataTemplate>
                            </ContentPresenter.ContentTemplate>
                        </ContentPresenter>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
