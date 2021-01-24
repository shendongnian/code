    <DataGridComboBoxColumn Header="Programmer"
                            DisplayMemberPath="Name"
                            SelectedItemBinding="{Binding Programmer}">
      <DataGridComboBoxColumn.ElementStyle>
        <Style>
          <Setter Property="ComboBox.ItemsSource" Value="{Binding Programmers}" />
        </Style>
      </DataGridComboBoxColumn.ElementStyle>
      <DataGridComboBoxColumn.EditingElementStyle>
        <Style>
          <Setter Property="ComboBox.ItemsSource" Value="{Binding Programmers}" />
        </Style>
      </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
