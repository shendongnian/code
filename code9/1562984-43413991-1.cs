	<MultiTrigger>
		<MultiTrigger.Conditions>
			<Condition Property="IsFocused" Value="False"/>
			<Condition Property="Text" Value=""/>
		</MultiTrigger.Conditions>
		<Setter Property="Visibility" TargetName="WARKTEXT" Value="Visible"/>
	</MultiTrigger>
	<MultiTrigger>
		<MultiTrigger.Conditions>
			<Condition Property="IsFocused" Value="False"/>
			<Condition Property="Text" Value="{x:Null}"/>
		</MultiTrigger.Conditions>
		<Setter Property="Visibility" TargetName="WARKTEXT" Value="Visible"/>
	</MultiTrigger>
