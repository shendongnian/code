    <ListBox.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <ComboBox x:Name="cb" SelectedIndex="0">
                    <ComboBoxItem>Yes</ComboBoxItem>
                    <ComboBoxItem>No</ComboBoxItem>
                </ComboBox>
                <TextBox Grid.Column="1">
                    <TextBox.Style>
                        <Style TargetType="TextBox">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding SelectedIndex, ElementName=cb}"
                                             Value="0">
                                    <Setter Property="IsReadOnly" Value="True"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBox.Style>
                </TextBox>
            </Grid>
        </DataTemplate>
    </ListBox.ItemTemplate>
