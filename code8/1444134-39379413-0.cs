    <ToggleButton Content="Boaty McBoatFace" HorizontalAlignment="Center" VerticalAlignment="Center">
                <ToggleButton.Template>
                    <ControlTemplate TargetType="{x:Type ToggleButton}">
                        <ControlTemplate.Resources>
    
                            <Storyboard x:Key="bubbleAnim">
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble1">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble1">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble2">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble3">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="210"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble3">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble4">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="210"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble4">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="133"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble5">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="210"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble5">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="205"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble6">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="205"/>
                                </DoubleAnimationUsingKeyFrames>
                                <Int32AnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.ZIndex)" Storyboard.TargetName="bubble6">
                                    <EasingInt32KeyFrame KeyTime="0:0:0.7" Value="-5"/>
                                </Int32AnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble7">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble7">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="205"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" Storyboard.TargetName="bubble8">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="55"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="bubble8">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="133"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble1">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble2">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble3">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble4">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble5">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble6">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="0.985"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble7">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="bubble8">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line1">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line2">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line3">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line4">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line5">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line6">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line7">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="line8">
                                    <EasingDoubleKeyFrame KeyTime="0:0:0.9" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
    
                        </ControlTemplate.Resources>
    
                        <Border Height="300" Width="300">
                            <Canvas>
                                <Canvas.Resources>
                                    <Style TargetType="Line">
                                        <Setter Property="VerticalAlignment" Value="Center"/>
                                        <Setter Property="Stroke" Value="Red"/>
                                        <Setter Property="StrokeThickness" Value="2"/>
                                    </Style>
                                    <Style TargetType="Border">
                                        <Setter Property="Background" Value="White"/>
                                        <Setter Property="BorderBrush" Value="Purple"/>
                                        <Setter Property="BorderThickness" Value="3"/>
                                        <Setter Property="CornerRadius" Value="50"/>
                                        <Setter Property="Padding" Value="10,5"/>
                                    </Style>
                                </Canvas.Resources>
    
                                <Line x:Name="line1" Opacity="0" 
                                          X1="75" Y1="75"
                                          X2="150" Y2="150"/>
                                <Line x:Name="line2" Opacity="0"
                                          X1="150" Y1="75"
                                          X2="150" Y2="150" Stroke="Blue"/>
                                <Line x:Name="line3" Opacity="0"
                                          X1="225" Y1="75"
                                          X2="150" Y2="150"/>
                                <Line x:Name="line4" Opacity="0"
                                          X1="225" Y1="150"
                                          X2="150" Y2="150" Stroke="Blue"/>
                                <Line x:Name="line5" Opacity="0"
                                          X1="150" Y1="150"
                                          X2="75" Y2="225"/>
                                <Line x:Name="line6" Opacity="0"
                                          X1="150" Y1="150"
                                          X2="150" Y2="225" Stroke="Blue"/>
                                <Line x:Name="line7" Opacity="0"
                                          X1="150" Y1="150"
                                          X2="225" Y2="225"/>
                                <Line x:Name="line8" Opacity="0"
                                          X1="150" Y1="150"
                                          X2="75" Y2="150" Stroke="Blue"/>
    
    
                                <Border x:Name="bubble1" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="1"/>
                                </Border>
    
                                <Border x:Name="bubble2" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="2"/>
                                </Border>
    
                                <Border x:Name="bubble3" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="3"/>
                                </Border>
    
                                <Border x:Name="bubble4" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="4"/>
                                </Border>
    
                                <Border x:Name="bubble5" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="5"/>
                                </Border>
    
                                <Border x:Name="bubble6" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="6"/>
                                </Border>
    
                                <Border x:Name="bubble7" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="7"/>
                                </Border>
    
                                <Border x:Name="bubble8" Opacity="0"
                                        Canvas.Left="133" Canvas.Top="134">
                                    <TextBlock Text="8"/>
                                </Border>
    
                                <Border CornerRadius="3" Background="{TemplateBinding Background}"
                                        Canvas.Left="95" Canvas.Top="138" Padding="1">
                                    <ContentPresenter />
                                </Border>
    
    
                            </Canvas>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource bubbleAnim}"/>
                                </Trigger.EnterActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </ToggleButton.Template>
            </ToggleButton>
