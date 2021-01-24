    <TabControl Grid.Row="1"
                        Grid.Column="0"
                        VerticalAlignment="Stretch"
                        BorderThickness="0.5"
                        BorderBrush="Black"
                        ContentTemplateSelector="{StaticResource Selector}">
                <TabControl.Resources>
                    <CollectionViewSource Source="{Binding Model.DetailsVM}" x:Key="Tabs">
                    </CollectionViewSource>
                </TabControl.Resources>
                <TabControl.ItemsSource>
                    <CompositeCollection>
                        <!--Result View-->
                        <TabItem Header="Import" Content="{Binding ResultViewModel}">
                            <!--<ContentControl DataContext="{Binding ResultViewModel}"/>-->
                        </TabItem>
    
                        <!--Configuration Tab-->
                        <TabItem Header="Configuration" Content="{Binding ConfigViewModel}">
                            <!--<ContentControl Content="{Binding ConfigViewModel}"/>-->
                        </TabItem>
    
                        <!--Others-->
                        <CollectionContainer Collection="{Binding Source={StaticResource Tabs}}"/>
                    </CompositeCollection>
                </TabControl.ItemsSource>
                
    </TabControl>
