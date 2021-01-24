    <DataGridTextColumn x:Name="Type" Binding="{Binding TypeOfData, Mode=OneTime}" SortMemberPath="TypeOfData" IsReadOnly="true" CanUserSort="true">
        <DataGridTextColumn.Header>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="Auto" />
                </Grid.ColumnDefinitions>
                <Label Content="Type Of Data"  />
                <ComboBox x:Name="comboBoxType" Grid.Column="1" SelectionChanged="comboBoxType_SelectionChanged">
                    <ComboBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel x:Name="itemsComboBox">
                                <CheckBox Name="checkBoxType" IsChecked="False" Content="{Binding Key}" Unchecked="FilterChange" Checked="FilterChange"/>
                            </StackPanel>
                        </DataTemplate>
                    </ComboBox.ItemTemplate>
                </ComboBox>
                <Button Content="Check" Grid.Column="2" />
            </Grid>
        </DataGridTextColumn.Header>
    </DataGridTextColumn>
