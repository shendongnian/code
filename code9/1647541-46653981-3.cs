    <Window ...>
        <Window.DataContext>
            <local:MainViewModel/>
        </Window.DataContext>
        <Grid>
            <TabControl Name="TCMain"
                ItemsSource="{Binding ViewModels}"
                DisplayMemberPath="Title"
                SelectedItem="{Binding CurrentViewModel}"
                Background="#00FFFFFF" BorderThickness="0" Padding="0 -5 0 0 ">
                <TabControl.ContentTemplate>
                    <DataTemplate>
                        <ContentControl Content="{Binding}">
                            <ContentControl.Resources>
                                <DataTemplate DataType="{x:Type local:NameViewModel}">
                                    <local:NameView />
                                </DataTemplate>
                                <DataTemplate DataType="{x:Type local:CodeViewModel}">
                                    <local:CodeView />
                                </DataTemplate>
                                <DataTemplate DataType="{x:Type local:FactorDetailViewModel}">
                                    <local:FactorDetailView />
                                </DataTemplate>
                            </ContentControl.Resources>
                        </ContentControl>
                    </DataTemplate>
                </TabControl.ContentTemplate>
            </TabControl>
        </Grid>
    </Window>
