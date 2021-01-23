        <Grid>
        <DataGrid x:Name="dg_TimeTable" AutoGenerateColumns="False" Margin="0,0,0,97" ColumnWidth="*" PreparingCellForEdit="dg_TimeTable_PreparingCellForEdit">
            <DataGrid.Columns>
                <DataGridTextColumn IsReadOnly="True" Binding="{Binding CLASS}" Header="CLASS" />
                <DataGridComboBoxColumn Header="PERIOD" x:Name="gPeriods" SelectedValueBinding="{Binding PERIOD, Mode=TwoWay}" DisplayMemberPath="{Binding PERIOD}" />
                <DataGridComboBoxColumn Header="TEACHERS" x:Name="gTeachers" SelectedValueBinding="{Binding TEACHER, Mode=TwoWay}" DisplayMemberPath="{Binding TEACHER}" />
                <DataGridTemplateColumn Header="TEACHERS" x:Name="colTeacherList" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path=TEACHER, Mode=TwoWay, UpdateSourceTrigger=LostFocus}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox Name="cmbTeacherList" SelectedItem="{Binding myItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                
                <DataGridComboBoxColumn Header="SUBJECTS" x:Name="gSubjects" SelectedValueBinding="{Binding SUBJECT, Mode=TwoWay}" DisplayMemberPath="{Binding SUBJECT}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
