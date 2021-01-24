    <ControlTemplate TargetType="GridView">
        <Grid BorderBrush="{TemplateBinding BorderBrush}"
              BorderThickness="{TemplateBinding BorderThickness}"
              Background="{TemplateBinding Background}">
            <ScrollViewer x:Name="ScrollViewer"
                          AutomationProperties.AccessibilityView="Raw"
                          BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                          HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                          HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                          IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                          IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                          IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                          IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                          IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                          TabNavigation="{TemplateBinding TabNavigation}"
                          VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                          VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                          ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                <ItemsPresenter FooterTransitions="{TemplateBinding FooterTransitions}"
                                FooterTemplate="{TemplateBinding FooterTemplate}"
                                Footer="{TemplateBinding Footer}"
                                HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                Header="{TemplateBinding Header}"
                                HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                Padding="{TemplateBinding Padding}" />
            </ScrollViewer>
            <ProgressBar x:Name="StatusBar"
                         IsIndeterminate="{Binding IsHitTestVisible, RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource InvertBoolConverter}}" />
        </Grid>
    </ControlTemplate>
