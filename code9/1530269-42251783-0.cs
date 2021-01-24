    <ComboBox x:Name="cbo" ItemsSource="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}},Path=DataContext.ColumnOptions}"
                      SelectionChanged="cbo_SelectionChanged">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock x:Name="txt" Text="{Binding Name}"/>
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding Path=SelectedItem.IsDuplicate, RelativeSource={RelativeSource AncestorType=ComboBox}}" Value="True">
                        <Setter TargetName="txt" Property="Background" Value="Red"/>
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
