     <ItemsControl ItemsSource="{Binding List}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel IsItemsHost="True"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Expander Header="{Binding SomeText}" MinWidth="100">
                    <StackPanel Orientation="Horizontal">
                        <TextBox Text="{Binding SomeText}" MinWidth="100"/>
                        <Button MaxWidth="150" Content="ClickMeToGetYourText" Command="{Binding DataContext.ButtonClickedCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}}" CommandParameter="{Binding}"/>
                    </StackPanel>
                </Expander>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
