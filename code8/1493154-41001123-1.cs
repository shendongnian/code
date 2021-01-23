	<ItemsControl ItemsSource="{Binding VehCollection}">
		<ItemsControl.ItemTemplate>
			<DataTemplate>
				<Grid>
					<Grid.ColumnDefinitions>
						<ColumnDefinition Width="39.8" />
						<ColumnDefinition Width="39.8" />
						<ColumnDefinition Width="80"  />
						<ColumnDefinition Width="80" />
					</Grid.ColumnDefinitions>
					<TextBox Text="{Binding Alt}" Grid.Column="0"/>
					<TextBox Text="{Binding Depth}"  Grid.Column="1"/>
				</Grid>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
