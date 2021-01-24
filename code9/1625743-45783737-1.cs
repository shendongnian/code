            <Style TargetType="ListView"
                   x:Key="SnapListViewStyle">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListView">
                            <Border BorderBrush="{TemplateBinding BorderBrush}"
                                    Background="{TemplateBinding Background}"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                <ScrollViewer x:Name="ScrollViewer"
                                              TabNavigation="{TemplateBinding TabNavigation}"
                                              HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                              HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                              IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                              VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                              VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                              IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                                              IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                              IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                              VerticalSnapPointsAlignment="Near"
                                              VerticalSnapPointsType="MandatorySingle"
                                              ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}"
                                              IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                              BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                                              AutomationProperties.AccessibilityView="Raw">
                                    <ItemsPresenter Header="{TemplateBinding Header}"
                                                    HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                                    HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                                    Footer="{TemplateBinding Footer}"
                                                    FooterTemplate="{TemplateBinding FooterTemplate}"
                                                    FooterTransitions="{TemplateBinding FooterTransitions}"
                                                    Padding="{TemplateBinding Padding}" />
                                </ScrollViewer>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
