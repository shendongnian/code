     <StackPanel Background="Transparent">
      <i:Interaction.Triggers>
        <i:EventTrigger EventName="Tap">
          <command:EventToCommand
            Command="{Binding Main.NavigateToArticleCommand,
              Mode=OneWay,
              Source={StaticResource Locator}}"
            CommandParameter="{Binding Mode=OneWay}" />
        </i:EventTrigger>
      </i:Interaction.Triggers>
    </StackPanel>
