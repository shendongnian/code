    <Application.Resources>
    <ResourceDictionary>     
        <CollectionViewSource Source="{Binding Matches}" x:Key="GroupedItems">
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="MatchNation" />
                <PropertyGroupDescription PropertyName="MatchLeague" />
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
    </ResourceDictionary>
    </Application.Resources>
