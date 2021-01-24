    <DatePicker>
        <DatePicker.Resources>
            <Style TargetType="DatePickerTextBox">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DatePickerTextBox}">
                            <Grid>
                                <Grid.Resources>
                                    <SolidColorBrush x:Key="WatermarkBrush" Color="#FFAAAAAA"/>
                                </Grid.Resources>
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition GeneratedDuration="0"/>
                                            <VisualTransition GeneratedDuration="0:0:0.1" To="MouseOver"/>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver" />
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="WatermarkStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition GeneratedDuration="0"/>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Unwatermarked"/>
                                        <VisualState x:Name="Watermarked">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ContentElement"/>
                                                <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="PART_Watermark"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="FocusStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition GeneratedDuration="0"/>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Unfocused"/>
                                        <VisualState x:Name="Focused" />
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Border x:Name="Border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" CornerRadius="1" Opacity="1" Padding="{TemplateBinding Padding}">
                                    <Grid x:Name="WatermarkContent" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                                        <Border x:Name="ContentElement" BorderBrush="#FFFFFFFF" BorderThickness="1"/>
                                        <Border x:Name="watermark_decorator" BorderBrush="#FFFFFFFF" BorderThickness="1">
                                            <ContentControl x:Name="PART_Watermark" Focusable="False" IsHitTestVisible="False" Opacity="0" Padding="2"/>
                                        </Border>
                                        <ScrollViewer x:Name="PART_ContentHost" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="0" VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                    </Grid>
                                </Border>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DatePicker.Resources>
    </DatePicker>
