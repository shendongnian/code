    <DataGridTemplateColumn Width="Auto" CanUserSort="True" CanUserResize="True">
					<DataGridTemplateColumn.HeaderTemplate>
						<DataTemplate>
							<CheckBox x:Name="chkMailAll" Content="{DynamicResource String.EquipmentView.CheckEnvoiMail}"
                                      Checked="chkAll_Checked" Unchecked="chkAll_Unchecked" />
						</DataTemplate>
					</DataGridTemplateColumn.HeaderTemplate>
					<DataGridTemplateColumn.CellTemplate>
						<DataTemplate>
                            <CheckBox IsChecked="{Binding EnvoiMail,UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
					</DataGridTemplateColumn.CellTemplate>
				</DataGridTemplateColumn>
				<DataGridTemplateColumn Width="Auto" CanUserSort="True" CanUserResize="True">
					<DataGridTemplateColumn.HeaderTemplate>
						<DataTemplate>
							<CheckBox x:Name="chkActiveAll" Content="{DynamicResource String.EquipmentView.CheckActif}"
                                      Checked="chkAll_Checked" Unchecked="chkAll_Unchecked" />
						</DataTemplate>
					</DataGridTemplateColumn.HeaderTemplate>
					<DataGridTemplateColumn.CellTemplate>
						<DataTemplate>
							<CheckBox IsChecked="{Binding Actif,UpdateSourceTrigger=PropertyChanged}" />
						</DataTemplate>
					</DataGridTemplateColumn.CellTemplate>
				</DataGridTemplateColumn>
				<DataGridTemplateColumn Width="Auto" CanUserSort="True" CanUserResize="True">
					<DataGridTemplateColumn.HeaderTemplate>
						<DataTemplate>
							<CheckBox x:Name="chkRemoveAll" Content="{DynamicResource String.EquipmentView.CheckDeleted}"
                                      Checked="chkAll_Checked" Unchecked="chkAll_Unchecked" />
						</DataTemplate>
					</DataGridTemplateColumn.HeaderTemplate>
					<DataGridTemplateColumn.CellTemplate>
						<DataTemplate>
                            <CheckBox IsChecked="{Binding Supprime,UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
					</DataGridTemplateColumn.CellTemplate>
				</DataGridTemplateColumn>
