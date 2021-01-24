    <telerik:RadButton Name="setting" CornerRadius="12" Click="settings_Click" Grid.Column="2" IsBackgroundVisible="False">
        <telerik:RadButton.Resources>
            <SolidColorBrush x:Key="ControlInnerBorder_Normal" Color="#FFFFFFFF"/>
            <LinearGradientBrush x:Key="ControlBackground_MouseOver" EndPoint="0.5,1" StartPoint="0.5,0">
                <GradientStop Color="#FFFFFBDA" Offset="0"/>
                <GradientStop Color="#FFFEEBAE" Offset="0.50"/>
                <GradientStop Color="#FFFFD25A" Offset="0.50"/>
                <GradientStop Color="#FFFFFBA3" Offset="1"/>
            </LinearGradientBrush>
            <SolidColorBrush x:Key="ControlOuterBorder_MouseOver" Color="#FFFFC92B"/>
            <SolidColorBrush x:Key="ControlInnerBorder_MouseOver" Color="#FFFFFFFF"/>
            <LinearGradientBrush x:Key="ControlBackground_Pressed" EndPoint="0.5,1" StartPoint="0.5,0">
                <GradientStop Color="#FFFFDCAB" Offset="0"/>
                <GradientStop Color="#FFFFD18F" Offset="0.5"/>
                <GradientStop Color="#FFFE9227" Offset="0.5"/>
                <GradientStop Color="#FFFFBA74" Offset="0"/>
            </LinearGradientBrush>
            <LinearGradientBrush x:Key="ControlOuterBorder_Pressed" EndPoint="0.5,1" StartPoint="0.5,0">
                <GradientStop Color="#FF282828"/>
                <GradientStop Color="#FF5F5F5F" Offset="1"/>
            </LinearGradientBrush>
            <LinearGradientBrush x:Key="ControlInnerBorder_Pressed" EndPoint="0.5,1" StartPoint="0.5,0">
                <GradientStop Color="#FFB69A78"/>
                <GradientStop Color="#FFFFE17A" Offset="0.126"/>
            </LinearGradientBrush>
            <SolidColorBrush x:Key="ControlInnerBorder_Disabled" Color="Transparent"/>
            <SolidColorBrush x:Key="ControlBackground_Disabled" Color="#FFE0E0E0"/>
            <SolidColorBrush x:Key="ControlBackground_Focused" Color="Transparent"/>
            <SolidColorBrush x:Key="ControlOuterBorder_Focused" Color="#FFFFC92B"/>
            <SolidColorBrush x:Key="ControlInnerBorder_Focused" Color="Transparent"/>
        </telerik:RadButton.Resources>
        <Image Source="/CRI_12;component/Images/cog-64.png" RenderTransformOrigin=".5,.5" Stretch="Uniform">
            <Image.RenderTransform>
                <RotateTransform x:Name="AnimatedRotate" Angle="0" />
            </Image.RenderTransform>
            <Image.Style>
                <Style TargetType="Image">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsMouseOver, RelativeSource={RelativeSource Self}}" Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard Name="sb">
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetProperty="RenderTransform.(RotateTransform.Angle)"
                                                 By="0"        
                                                 To="45" 
                                                 Duration="0:0:.5" 
                                                 FillBehavior="Stop" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                            <DataTrigger.ExitActions>
                                <RemoveStoryboard BeginStoryboardName="sb" />
                            </DataTrigger.ExitActions>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Image.Style>
        </Image>
        <telerik:RadButton.Template>
            <ControlTemplate TargetType="telerik:RadButton">
                <Grid SnapsToDevicePixels="True">
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal"/>
                            <VisualState x:Name="MouseOver">
                                <Storyboard>
                                    <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="OuterMouseOverBorder"/>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Pressed">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="OuterPressedBorder" Storyboard.TargetProperty="Visibility">
                                        <DiscreteObjectKeyFrame KeyTime="0">
                                            <DiscreteObjectKeyFrame.Value>
                                                <Visibility>Visible</Visibility>
                                            </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                    </ObjectAnimationUsingKeyFrames>
                                    <DoubleAnimation Duration="0" Storyboard.TargetName="CommonStatesWrapper" Storyboard.TargetProperty="Opacity" To="0"/>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Disabled">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="DisabledVisual" Storyboard.TargetProperty="Visibility">
                                        <DiscreteObjectKeyFrame KeyTime="0">
                                            <DiscreteObjectKeyFrame.Value>
                                                <Visibility>Visible</Visibility>
                                            </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                    </ObjectAnimationUsingKeyFrames>
                                    <DoubleAnimation Duration="0" Storyboard.TargetName="Content" Storyboard.TargetProperty="Opacity" To="0.5"/>
                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                        <VisualStateGroup x:Name="BackgroundVisibility">
                            <VisualState x:Name="BackgroundIsHidden">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="OuterBorder" Storyboard.TargetProperty="Visibility">
                                        <DiscreteObjectKeyFrame KeyTime="0">
                                            <DiscreteObjectKeyFrame.Value>
                                                <Visibility>Collapsed</Visibility>
                                            </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                    </ObjectAnimationUsingKeyFrames>
                                    <DoubleAnimation Duration="0" Storyboard.TargetName="DisabledVisual" Storyboard.TargetProperty="Opacity" To="0"/>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="BackgroundIsVisible"/>
                        </VisualStateGroup>
                        <VisualStateGroup x:Name="FocusStatesGroup">
                            <VisualState x:Name="Unfocused">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="FocusVisual" Storyboard.TargetProperty="Visibility">
                                        <DiscreteObjectKeyFrame KeyTime="00:00:00.150">
                                            <DiscreteObjectKeyFrame.Value>
                                                <Visibility>Collapsed</Visibility>
                                            </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                            <!--<VisualState x:Name="Focused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="FocusVisual" Storyboard.TargetProperty="Visibility">
                                                <DiscreteObjectKeyFrame KeyTime="00:00:00.115">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>-->
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                    <Border x:Name="OuterBorder"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    Background="{TemplateBinding Background}"
                                    CornerRadius="{TemplateBinding CornerRadius}">
                        <Border
                                        BorderThickness="{TemplateBinding BorderThickness}"
                                        Background="{x:Null}"
                                        CornerRadius="{TemplateBinding InnerCornerRadius}"
                                        BorderBrush="{StaticResource ControlInnerBorder_Normal}"/>
                    </Border>
                    <Border x:Name="OuterMouseOverBorder"
                                    Opacity="0"
                                    CornerRadius="{TemplateBinding CornerRadius}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{StaticResource ControlBackground_MouseOver}"
                                    BorderBrush="{StaticResource ControlOuterBorder_MouseOver}">
                        <Border
                                        BorderThickness="{TemplateBinding BorderThickness}"
                                        Background="{x:Null}"
                                        CornerRadius="{TemplateBinding InnerCornerRadius}"
                                        BorderBrush="{StaticResource ControlInnerBorder_MouseOver}"/>
                    </Border>
                    <Border x:Name="OuterPressedBorder"
                                    Visibility="Collapsed"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    CornerRadius="{TemplateBinding CornerRadius}"
                                    Background="{StaticResource ControlBackground_Pressed}"
                                    BorderBrush="{StaticResource ControlOuterBorder_Pressed}">
                        <Border
                                        BorderThickness="{TemplateBinding BorderThickness}"
                                        Background="{x:Null}"
                                        CornerRadius="{TemplateBinding InnerCornerRadius}"
                                        BorderBrush="{StaticResource ControlInnerBorder_Pressed}"/>
                    </Border>
                    <Border x:Name="DisabledVisual"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    CornerRadius="{TemplateBinding CornerRadius}"
                                    Visibility="Collapsed"
                                    BorderBrush="{StaticResource ControlInnerBorder_Disabled}"
                                    Background="{StaticResource ControlBackground_Disabled}"/>
                    <ContentPresenter x:Name="Content"
                                    TextBlock.Foreground="{TemplateBinding Foreground}"
                                    Margin="{TemplateBinding Padding}"
                                    Content="{TemplateBinding Content}"
                                    ContentTemplate="{TemplateBinding ContentTemplate}"
                                    VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                    HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                    ContentTemplateSelector="{TemplateBinding ContentTemplateSelector}"
                                    ContentStringFormat="{TemplateBinding ContentStringFormat}"
                                    RecognizesAccessKey="True"/>
                    <Border x:Name="CommonStatesWrapper">
                        <Border x:Name="FocusVisual"
                                        BorderThickness="{TemplateBinding BorderThickness}"
                                        CornerRadius="{TemplateBinding CornerRadius}"
                                        Visibility="Collapsed"
                                        Background="{StaticResource ControlBackground_Focused}"
                                        BorderBrush="{StaticResource ControlOuterBorder_Focused}">
                            <Border BorderThickness="1" BorderBrush="{StaticResource ControlInnerBorder_Focused}" CornerRadius="{TemplateBinding InnerCornerRadius}"/>
                        </Border>
                    </Border>
                </Grid>
            </ControlTemplate>
        </telerik:RadButton.Template>
    </telerik:RadButton>
