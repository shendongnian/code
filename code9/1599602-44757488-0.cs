	<DataGrid ItemsSource="{Binding Customers}" AutoGenerateColumns="False" >
		<DataGrid.Columns>
			<DataGridTextColumn Header="Name" Binding="{Binding Name}" />
			<DataGridTemplateColumn Header="Image" Width="SizeToCells" IsReadOnly="True">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<Image Source="{Binding Image}" />
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
