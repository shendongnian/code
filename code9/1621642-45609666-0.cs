    <Style TargetType="{x:Type local:ClickableBorder}">
        <Setter Property="BorderBrush" Value="Black"/>
        <Setter Property="Background" Value="LightGray"/>
        <Style.Triggers>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsMouseOver"  Value="True"/>
                    <Condition Property="IsEnabled"  Value="True"/>
                </MultiTrigger.Conditions>
                <MultiTrigger.EnterActions>
                    <BeginStoryboard Name="sb">
                        <Storyboard>
                            <ColorAnimation Duration="0:0:0.200" To="White" Storyboard.TargetProperty="BorderBrush.Color"/>
                            <ColorAnimation Duration="0:0:0.200" To="DarkGray" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiTrigger.EnterActions>
                <MultiTrigger.ExitActions>
                    <RemoveStoryboard BeginStoryboardName="sb" />
                </MultiTrigger.ExitActions>
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="local:FrameworkElementExt.IsPressed"  Value="True"/>
                    <Condition Property="IsEnabled"  Value="True"/>
                </MultiTrigger.Conditions>
                <MultiTrigger.EnterActions>
                    <BeginStoryboard Name="sb2">
                        <Storyboard>
                            <ColorAnimation Duration="0:0:0.200" To="DarkRed" Storyboard.TargetProperty="BorderBrush.Color"/>
                            <ColorAnimation Duration="0:0:0.200" To="Red" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiTrigger.EnterActions>
                <MultiTrigger.ExitActions>
                    <RemoveStoryboard BeginStoryboardName="sb2" />
                </MultiTrigger.ExitActions>
            </MultiTrigger>
        </Style.Triggers>
    </Style>
