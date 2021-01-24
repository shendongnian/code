    <ListView x:Name="TemplateListView" ItemsSource="{Binding TemplateListItems}" SelectedValue="{Binding SelectedTemplate}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <CheckBox Content="{Binding Name}" IsChecked="{Binding Use}" Command="{Binding TemplateListChangedCommand}" />
                    <TextBox Text="{Binding Message}" Grid.Column="1" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
