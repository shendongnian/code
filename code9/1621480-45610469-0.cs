    <ListView x:Name="TemplateListView" ItemsSource="{Binding TemplateListItems}" SelectedValue="{Binding SelectedTemplate}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <CheckBox Content="{Binding Name}" IsChecked="{Binding Use}" Command="{Binding TemplateListChangedCommand}" />
                    <TextBox Text="{Binding Message}" Grid.Row="1" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
