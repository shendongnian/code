    <Style TargetType="{x:Type Button}" x:Key="WindowButtonStyle">
        <Setter Property="Width" Value="46" />
        <Setter Property="Height" Value="32" />
        <Setter Property="BorderThickness" Value="0" />
        <Setter Property="VerticalAlignment" Value="Center" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{TemplateBinding Background}">
                        <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalAlignment}" VerticalAlignment="{TemplateBinding VerticalAlignment}" />
                    </Border>
                    <ControlTemplate.Resources>
                        <Storyboard x:Key="MouseOverAnimation">
                            <DoubleAnimation Storyboard.TargetName="border" Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)" To="1.0" Duration="0:0:0.15" />
                        </Storyboard>
                        <Storyboard x:Key="MouseOutAnimation">
                            <DoubleAnimation Storyboard.TargetName="border" Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)" To="0.0" Duration="0:0:0.15" />
                        </Storyboard>
                    </ControlTemplate.Resources>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard Storyboard="{StaticResource MouseOverAnimation}" />
                            </Trigger.EnterActions>
                            <Trigger.ExitActions>
                                <BeginStoryboard Storyboard="{StaticResource MouseOutAnimation}" />
                            </Trigger.ExitActions>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
