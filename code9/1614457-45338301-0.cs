    <Application.Resources>
        <x:Double x:Key="ListViewHeaderHeight">200</x:Double>
        <Thickness x:Key="ListViewContentMargin" Top="{StaticResource ListViewHeaderHeight}"></Thickness>
        <Style x:Key="BlurredHeaderListViewStyle" TargetType="ListView">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListView">
                        <Grid BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}">
                            <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}" IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" TabNavigation="{TemplateBinding TabNavigation}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                                <ItemsPresenter Margin="{StaticResource ListViewContentMargin}" FooterTransitions="{TemplateBinding FooterTransitions}" FooterTemplate="{TemplateBinding FooterTemplate}" Footer="{TemplateBinding Footer}" HeaderTransitions="{TemplateBinding HeaderTransitions}" Padding="{TemplateBinding Padding}"/>
                            </ScrollViewer>
                            <ContentPresenter x:Name="HeaderPresenter" Background="Transparent" Height="{StaticResource ListViewHeaderHeight}" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" VerticalAlignment="Top">
                                <interactivity:Interaction.Behaviors>
                                    <behaviors:Blur x:Name="BlurBehavior" Value="12" />
                                </interactivity:Interaction.Behaviors>
                            </ContentPresenter>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Application.Resources>
