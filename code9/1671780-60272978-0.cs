    <Grid.Resources>
        <CollectionViewSource x:Key="CollectionA" Source="{Binding CollectionA}" />
        <CollectionViewSource x:Key="CollectionB" Source="{Binding CollectionB}" />
        <CompositeCollection x:Key="FullCollection">
            <ListViewItem IsEnabled="False">Collection A:</ListViewItem>
            <CollectionContainer Collection="{Binding Source={StaticResource CollectionA}}" />
            <ListViewItem IsEnabled="False">Collection B:</ListViewItem>
            <CollectionContainer Collection="{Binding Source={StaticResource CollectionB}}" />
        </CompositeCollection>
    </Grid.Resources>
