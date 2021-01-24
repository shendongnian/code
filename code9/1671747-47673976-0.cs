    <ListBox ItemsSource="{Binding FoodItems}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox>
                        <CheckBox.IsChecked>
                            <MultiBinding Converter="{StaticResource ListExistsConverter}" Mode="OneWay">
                                <Binding/>
                                <Binding Path="DataContext.SelectedFoodItems" RelativeSource="{RelativeSource AncestorType=UserControl}"/>
                            </MultiBinding>
                        </CheckBox.IsChecked>
                    </CheckBox>
                    <TextBox Text="{Binding Name}" Width="50" Height="20"/>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
