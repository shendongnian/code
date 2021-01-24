    <Window.Resources>
        <ResourceDictionary>
            <DataTemplate DataType="{vm:MenuViewModel}">
                <Label>Menu View</Label>
            </DataTemplate>
            <DataTemplate DataType="{vm:OtherViewModel}">
                <Label>Menu View</Label>
            </DataTemplate>
        </ResourceDictionary>
    </Window.Resources>
    <DockPanel LastChildFill="True">
        <StackPanel DockPanel.Dock="Top">
            <Button Command="{Binding Button1Command}">Menu Button</Button>
            <Button Command="{Binding Button2Command}">Other Button</Button>
        </StackPanel>
        <ContentControl Content="{Binding CurrentView}"></ContentControl>
    </DockPanel>
