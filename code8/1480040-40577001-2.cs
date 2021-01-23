    <Style TargetType="Button">
      <Setter Property="HorizontalAlignment" Value="Center" />
      <Setter Property="FontFamily" Value="Comic Sans MS"/>
      <Setter Property="FontSize" Value="14"/>
    <EventTrigger RoutedEvent="Mouse.MouseEnter">
      <EventTrigger.Actions>
        <BeginStoryboard>
          <Storyboard>
            <DoubleAnimation
              Duration="0:0:0.2"
              Storyboard.TargetProperty="MaxHeight"
              To="90"  />
          </Storyboard>
        </BeginStoryboard>
      </EventTrigger.Actions>
    </EventTrigger>
    <EventTrigger RoutedEvent="Mouse.MouseLeave">
      <EventTrigger.Actions>
        <BeginStoryboard>
          <Storyboard>
            <DoubleAnimation
              Duration="0:0:1"
              Storyboard.TargetProperty="MaxHeight"  />
          </Storyboard>
        </BeginStoryboard>
      </EventTrigger.Actions>
    </EventTrigger>
    </Style>
