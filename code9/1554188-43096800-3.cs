        <ListView DataContext="{Binding YourClassName}" ItemsSource="{Binding PagedView}">
                        <ListView.Resources>
                            <DataTemplate DataType="{x:Type local:MappingObject
        <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="30"/>
                                            <ColumnDefinition Width="10"/>
                                            <ColumnDefinition Width="30"/>
                                         </Grid.ColumnDefinitions>
     <TextBlock  Grid.Row="0" Grid.Column="1" Text="{Binding EventID}">
     <TextBlock  Grid.Row="0" Grid.Column="2" Text="{Binding EventDescription}">
       </Grid>
