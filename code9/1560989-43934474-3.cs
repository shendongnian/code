	<Style x:Key="VisibilityAnimation">
		<Style.Triggers>
			<Trigger Property="utils:AnimateableVisibility.StartVisibility" Value="Hidden">
                <!-- This avoids the Animation in cases when the first evaluation of AnimateableVisibility.Visibility is false -->
				<Setter Property="UIElement.Visibility" Value="Hidden" />
			</Trigger>
			<Trigger Property="utils:AnimateableVisibility.Visibility" Value="Visible">
				<Trigger.EnterActions>
					<BeginStoryboard>
						<Storyboard TargetProperty="Opacity">
							<DoubleAnimation To="1" Duration="0:0:2"/>
						</Storyboard>
					</BeginStoryboard>
				</Trigger.EnterActions>
				<Trigger.ExitActions>
					<BeginStoryboard>
						<Storyboard TargetProperty="Opacity">
							<DoubleAnimation To="0" Duration="0:0:2"/>
						</Storyboard>
					</BeginStoryboard>
				</Trigger.ExitActions>
			</Trigger>
		</Style.Triggers>
	</Style>
