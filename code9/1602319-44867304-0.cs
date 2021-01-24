    <CommandBar Content="{Binding OtherViewModel, Source={StaticResource Locator}}">
        <CommandBar.ContentTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Status}"></TextBlock>
            </DataTemplate>
        </CommandBar.ContentTemplate>
            
        ...
    </CommandBar>
