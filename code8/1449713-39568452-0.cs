    <ListView ItemsSource="{Binding ImageItems}"
                Grid.Row="1">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <TextBlock Text="{Binding Path}"/>
                    <Image Grid.Row="1">
                        <Image.Source>
                            <BitmapImage UriSource="{Binding Path}"/>
                        </Image.Source>
                    </Image>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
