    <ControlTemplate.Triggers>
	<MultiTrigger>
		<MultiTrigger.Conditions>
			<Condition Property="IsMouseOver" Value="True"/>
			<Condition Property="IsSelected" Value="False"/>
		</MultiTrigger.Conditions>
		<MultiTrigger.EnterActions>
			<BeginStoryboard>
				<Storyboard>
					<ColorAnimation Storyboard.TargetName="Panel"  Duration="0:0:0.1" To="#5e6972" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
				</Storyboard>
			</BeginStoryboard>
		</MultiTrigger.EnterActions>
		<MultiTrigger.ExitActions>
			<BeginStoryboard>
				<Storyboard>
					<ColorAnimation Storyboard.TargetName="Panel" Duration="0:0:0.1" To="#424f5a" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
				</Storyboard>
			</BeginStoryboard>
		</MultiTrigger.ExitActions>
	</MultiTrigger>
	<MultiTrigger>
		<MultiTrigger.Conditions>
			<Condition Property="IsMouseOver" Value="True"/>
			<Condition Property="IsSelected" Value="True"/>
		</MultiTrigger.Conditions>
		<MultiTrigger.EnterActions>
			<BeginStoryboard>
				<Storyboard>
					<ColorAnimation Storyboard.TargetName="Panel"  Duration="0:0:0.1" To="#5e6972" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
				</Storyboard>
			</BeginStoryboard>
		</MultiTrigger.EnterActions>
		<MultiTrigger.ExitActions>
			<BeginStoryboard>
				<Storyboard>
					<ColorAnimation Storyboard.TargetName="Panel" Duration="0:0:0.1" To="#383838" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
				</Storyboard>
			</BeginStoryboard>
		</MultiTrigger.ExitActions>
	</MultiTrigger>
	<MultiTrigger>
		<MultiTrigger.Conditions>
			<Condition Property="IsMouseOver" Value="False"/>
			<Condition Property="IsSelected" Value="True"/>
		</MultiTrigger.Conditions>
		<MultiTrigger.Setters>
			<Setter TargetName="Panel" Property="Background" Value="#383838"/>
		</MultiTrigger.Setters>
	</MultiTrigger>
    </ControlTemplate.Triggers>
