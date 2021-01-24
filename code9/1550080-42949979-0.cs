    <ControlTemplate x:Key="MyListViewControlTemplate">
        <ListView Name="MyListView" ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type mynameSpace:MyClass}}, Path=ItemsSource}">
            <ListView.View>
                <GridView >
                    <GridViewColumn Header="Details">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding DisplayValue}">
                                            <i:Interaction.Triggers>
                                                <i:EventTrigger EventName="MouseLeftButtonUp">
                                                    <i:InvokeCommandAction Command="{Binding}"></i:InvokeCommandAction>
                                                </i:EventTrigger>
                                            </i:Interaction.Triggers>
                                </TextBlock>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </ControlTemplate>
