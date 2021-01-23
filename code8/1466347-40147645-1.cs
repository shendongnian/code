    <Window.Resources>
        <CollectionViewSource x:Key="ViewSource1" Source="{Binding VT}"/>
        <CollectionViewSource x:Key="ViewSource2" Source="{Binding VP}"/>
 
        <CompositeCollection x:Key="CombinedCollection">
            <CollectionContainer Collection="{Binding Source={StaticResource ViewSource1}}" />
            <CollectionContainer Collection="{Binding Source={StaticResource ViewSource2}}" />
         </CompositeCollection>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <DataGrid ItemsSource="{StaticResource CombinedCollection}">
           
            <DataGrid.Columns>
                <DataGridTextColumn Header="AMP" Binding="{Binding ID}" Width="100"/>
                <DataGridTextColumn Header="PW" Binding="{Binding Name}" Width="100" />
                <DataGridTextColumn Header="DZ0" Binding="{Binding xaxa}" Width="100" />
                <DataGridTextColumn Header="DELTA" Binding="{Binding Description}" Width="100" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
