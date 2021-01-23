    <Style.Triggers>
		<MultiDataTrigger>
			<MultiDataTrigger.Conditions>
				<Condition Binding="{Binding NumberOfOrder}" Value="1" />
				<Condition Binding="{Binding IsLastRow}" Value="True" />
			</MultiDataTrigger.Conditions>
			<Setter Property="Background" Value="Red" />
		</MultiDataTrigger>
		...
	</Style.Triggers>					
