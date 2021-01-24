    <ContentPage.Resources>
        <ResourceDictionary>
            <local:DateConverter x:Key="DateConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <StackLayout>
        <ListView
            GroupDisplayBinding="{Binding Date, Converter={StaticResource DateConverter}}"
            IsGroupingEnabled="True"
            ItemsSource="{Binding Events}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextCell Text="{Binding Name}" />
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackLayout>
