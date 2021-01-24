                <DataGrid Grid.Row="0" x:Name="Dg_Test" 
                    Margin="2"
                    AutoGenerateColumns="False"
                    SelectedCellsChanged="dg_Test_SelectionChanged"
                    SelectionMode="Single"
                    MouseLeftButtonDown="Dg_TestMouseClick"
                    RowDetailsVisibilityMode="{Binding RowDetailsVisible}"
                    ScrollViewer.VerticalScrollBarVisibility="Visible"
                    Style="{StaticResource DatagridDesktopStyle}">
					<DataGrid.Columns>
						...
						<DataGridTemplateColumn Width="auto" IsReadOnly="True" Header="">
							DataGridTemplateColumn.HeaderTemplate>
							 ...
							</DataGridTemplateColumn.HeaderTemplate>
							<DataGridTemplateColumn.CellTemplate>
								<DataTemplate>
									<StackPanel>
										<Button x:Name="Btn_Edit"
												Click="Btn_EditTest_Click"/>
									</StackPanel>
								</DataTemplate>
							</DataGridTemplateColumn.CellTemplate>
						</DataGridTemplateColumn>
					</DataGrid.Columns>
			</DataGrid>
