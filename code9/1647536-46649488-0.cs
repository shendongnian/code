    <TabControl Name="TCMain"
                ItemsSource="{Binding ViewModels}"
                SelectedItem="{Binding ViewModel}"
                Background="#00FFFFFF" BorderThickness="0" Padding="0 -5 0 0 ">
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ContentControl Content="{Binding}">
                    <ContentControl.Resources>
                        <DataTemplate DataType="{x:Type local:NameViewViewModel}">
                            <views:NameView />
                        </DataTemplate>
                        <DataTemplate DataType="{x:Type local:CodeViewViewModel}">
                            <views:CodeView />
                        </DataTemplate>
                        <DataTemplate DataType="{x:Type local:FactorDetailViewModel}">
                            <views:FactorDetailView />
                        </DataTemplate>
                    </ContentControl.Resources>
                </ContentControl>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
