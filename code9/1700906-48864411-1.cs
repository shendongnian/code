    <TabControl Grid.Row="1" 
                        TabStripPlacement="Bottom"
                        ItemsSource="{Binding ListeTypeEquipements}"          
             >
                <TabControl.Resources>
                    <CollectionViewSource x:Key="Equipements" Source="{Binding ListeEquipements}"/>
                 </TabControl.Resources>
                <TabControl.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Nom}"/>
                    </DataTemplate>
                </TabControl.ItemTemplate>
                <TabControl.ContentTemplate>
                    <DataTemplate>
                        <Label Content="{Binding Source={StaticResource Equipements}, Path=Tag}"/>
                    </DataTemplate>
                </TabControl.ContentTemplate>
            </TabControl>
