	<Style.Triggers>
		<Trigger Property="IsEnabled" Value="False">
			<Trigger.EnterActions>
				<BeginStoryboard>
					<Storyboard>
						<DoubleAnimation
							Storyboard.TargetProperty="Opacity"
							From="1" To="0" Duration="0:0:0.5" />
						<ThicknessAnimation   
							Storyboard.TargetProperty="Margin"
							BeginTime="0:0:0.5"
							To="-600,50,0,0" 
							Duration="0:0:0" />
					</Storyboard>
				</BeginStoryboard>
			</Trigger.EnterActions>
			<Trigger.ExitActions>
				<BeginStoryboard>
					<Storyboard>
						<DoubleAnimation
							Storyboard.TargetProperty="Opacity"
							From="0" To="1" Duration="0:0:0.5" />
						<ThicknessAnimation   
							Storyboard.TargetProperty="Margin"
							From="-600,50,0,0"
							To="0,50,0,0" 
							Duration="0:0:0.1"
						/>
					</Storyboard>
				</BeginStoryboard>
			</Trigger.ExitActions>
		</Trigger>
	</Style.Triggers>
