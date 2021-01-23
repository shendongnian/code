        <ItemsControl ItemsSource="{Binding MyCollection}">
            <!-- ItemsPanelTemplate -->
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid Columns="2" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
     
            <!-- ItemTemplate -->
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Button Content="{Binding }" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
