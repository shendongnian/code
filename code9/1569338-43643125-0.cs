    <UserControl.DataContext>
        <TheViewModel:TheViewModelClass/>
    </UserControl.DataContext>
    <ListView ItemsSource="{Binding ListOfItems}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <CheckBox Content="{Binding Text}" IsChecked="{Binding CheckedStatus}" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
