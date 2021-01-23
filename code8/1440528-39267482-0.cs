		<DataGridTemplateColumn Header="Precios"  Width="100" >
		<DataGridTemplateColumn.CellTemplate>
			<DataTemplate>
				<ComboBox ItemsSource="{Binding Prices}">
					<ComboBox.ItemTemplate>
						<DataTemplate>
							<TextBlock Text="{Binding}"/>
						</DataTemplate>
					</ComboBox.ItemTemplate>
				</ComboBox>
			</DataTemplate>
		</DataGridTemplateColumn.CellTemplate>
		</DataGridTemplateColumn>
		<DataGridTemplateColumn Header="Presentaciónes"  Width="100" >
		<DataGridTemplateColumn.CellTemplate>
			<DataTemplate>
				<ComboBox ItemsSource="{Binding Presentations}">
					<ComboBox.ItemTemplate>
						<DataTemplate>
							<TextBlock Text="{Binding}"/>
						</DataTemplate>
					</ComboBox.ItemTemplate>
				</ComboBox>
			</DataTemplate>
		</DataGridTemplateColumn.CellTemplate>
		</DataGridTemplateColumn>
