     <Rectangle
         Grid.Row="0"
         Grid.ColumnSpan="3"
         Fill="Azure"
         Opacity="0.3">
         <ToolTipService.ToolTip>
             <ToolTip>
                 <ToolTip.Style>
                     <Style TargetType="ToolTip">
                         <Setter Property="Template">
                             <Setter.Value>
                                 <ControlTemplate TargetType="ToolTip">
                                     <ContentPresenter
                                         x:Name="LayoutRoot"
                                         MaxWidth="2000"
                                         Padding="{TemplateBinding Padding}"
                                         Background="{TemplateBinding Background}"
                                         BorderBrush="{TemplateBinding BorderBrush}"
                                         BorderThickness="{TemplateBinding BorderThickness}"
                                         Content="{TemplateBinding Content}"
                                         ContentTemplate="{TemplateBinding ContentTemplate}"
                                         ContentTransitions="{TemplateBinding ContentTransitions}"
                                         TextWrapping="Wrap">
                                         <VisualStateManager.VisualStateGroups>
                                             <VisualStateGroup x:Name="OpenStates">
                                                 <VisualState x:Name="Closed">
                                                     <Storyboard>
                                                         <FadeOutThemeAnimation TargetName="LayoutRoot" />
                                                     </Storyboard>
                                                 </VisualState>
                                                 <VisualState x:Name="Opened">
                                                     <Storyboard>
                                                         <FadeInThemeAnimation TargetName="LayoutRoot" />
                                                     </Storyboard>
                                                 </VisualState>
                                             </VisualStateGroup>
                                         </VisualStateManager.VisualStateGroups>
                                     </ContentPresenter>
                                 </ControlTemplate>
                             </Setter.Value>
                         </Setter>
                     </Style>
                 </ToolTip.Style>
                 <Grid>
                     <Grid.RowDefinitions>
                       ...
                     </Grid.RowDefinitions>
                     <Grid.ColumnDefinitions>
                       ...
                     </Grid.ColumnDefinitions>
                     <TextBlock
                         Grid.Row="0"
                         Grid.Column="0"
                         Text="testtriptext on column 0testtriptext on column 0testtriptext on column 0testtriptext on column 0" />
                     <TextBlock
                         Grid.Row="1"
                         Grid.Column="1"
                         Text="testtriptext on column 1" />
                     <TextBlock
                         Grid.Row="2"
                         Grid.Column="2"
                         Text="testtriptext on column 2" />
                 </Grid>
             </ToolTip>
         </ToolTipService.ToolTip>
     </Rectangle>
