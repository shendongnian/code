    <TabControl Grid.Row="1"
                        Grid.Column="0"
                        VerticalAlignment="Stretch"
                        BorderThickness="0.5"
                        BorderBrush="Black"
                        ContentTemplateSelector="{StaticResource Selector}">
                <TabControl.Resources>
                    <CollectionViewSource Source="{Binding Model.DetailsVM}" x:Key="Tabs"/>
                    <DataTemplate DataType="{x:Type viewModels:DetailedViewModel}">
                        <TextBlock Text="{Binding Model.SelectedItem.FileInfo.Name, Mode=OneWay}"/>
                    </DataTemplate>
                </TabControl.Resources>
                <TabControl.ItemsSource>
                    <CompositeCollection>
                        <!--Result View-->
                        <TabItem Header="Import" Content="{Binding ResultViewModel}"/>
                        <!--Configuration Tab-->
                        <TabItem Header="Configuration" Content="{Binding ConfigViewModel}"/>    
                        <!--Others-->
                        <CollectionContainer Collection="{Binding Source={StaticResource Tabs}}"/>
                    </CompositeCollection>
                </TabControl.ItemsSource>
                
    </TabControl>
