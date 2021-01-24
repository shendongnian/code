    <StackPanel>
        <Button Command="{Binding AddRowItemCommand}">Add Row</Button>
        <ItemsControl
            ItemsSource="{Binding RowItems}"
            >
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Button 
                        Content="{Binding Text}"    
                        ContentStringFormat="{}Delete {0}"
                        Command="{Binding DataContext.RemoveRowItemCommand, RelativeSource={RelativeSource AncestorType=ItemsControl}}" 
                        CommandParameter="{Binding}"
                        />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
        <ItemsControl
            ItemsSource="{Binding RowItems}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Label Content="{Binding Text}" ContentStringFormat="{}This is {0}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </StackPanel>
