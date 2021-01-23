    <ListBox ItemsSource="{Binding MyPlayers}" SelectedItem="{Binding SelectedPlayer}" Margin="69,51,347.4,161.8">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <ListBoxItem>
                    <CheckBox Content="{Binding Path=Pseudo}" >
                        <CheckBox.IsChecked>
                            <MultiBinding Converter="{StaticResource PlayerToTournamentRegistered}" Mode="OneWay">
                                <Binding />
                                <Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=Window}" Path="DataContext.MyTournament"/>
                            </MultiBinding>
                        </CheckBox.IsChecked>
                    </CheckBox>
                </ListBoxItem>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
