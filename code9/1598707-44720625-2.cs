	<ComboBox SelectedItem="{Binding Filter}">
		<ComboBox.ItemContainerStyle>
			<Style TargetType="ComboBoxItem">
				<Setter Property="Foreground" Value="Black"/> <!--Default Value-->
				<Style.Triggers>
					<DataTrigger Binding="{Binding}" Value="All"> <!--Using the default binding ie DataContext and if it has a Value of All do the following-->
						<Setter Property="Foreground" Value="Green"/>
					</DataTrigger>
				</Style.Triggers>
			</Style>
		</ComboBox.ItemContainerStyle>
		<ComboBox.ItemsSource>
			<CompositeCollection>
				<clr:String xmlns:clr="clr-namespace:System;assembly=mscorlib">All</clr:String> 
				<CollectionContainer Collection="{Binding Mode=OneWay, Source={StaticResource Statuses}}" />
			</CompositeCollection>
		</ComboBox.ItemsSource>
	</ComboBox>
