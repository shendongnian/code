    <Trigger Property="IsChecked" Value="True">
        <Trigger.EnterActions>
            <BeginStoryboard Storyboard="{StaticResource OnCheck}"/>
        </Trigger.EnterActions>
        <Trigger.ExitActions>
            <BeginStoryboard Storyboard="{StaticResource OnUnCheck}"/>
        </Trigger.ExitActions>
    </Trigger>
