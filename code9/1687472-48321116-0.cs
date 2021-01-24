     <ListView x:Name="listview" SeparatorVisibility="None" 
              HasUnevenRows="True" >
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="2"/>
                            <ColumnDefinition />
                            <BoxView  Grid.Column="0" Color="Green"/>
                            <StackLayout Grid.Column="1" Padding="20, 10">
                                <Label  Text="{Binding LoremIpsum}"
                                HorizontalOptions="Start"/>
                                <Label  Text="{Binding LoremIpsum1}" />
                                <Label  Text="{Binding LoremIpsum2}" />
                            </StackLayout>
                        </Grid.ColumnDefinitions>
                    </Grid>
                    
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
