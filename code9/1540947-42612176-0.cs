    <ComboBox ItemsSource="{Binding ComboItems}" SelectedValue="{Binding SelectedItem}">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=DataContext,RelativeSource={RelativeSource AncestorType=DataGridRow}}" 
                                                             Value="{x:Static CollectionView.NewItemPlaceholder}">
                        <Setter Property="IsEnabled" Value="False" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Converter={StaticResource ItemConverter}}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
