    <renderer:CustomListView x:Name="SomeList"
                HasUnevenRows="True"
                IsGroupingEnabled="True" 
                GroupDisplayBinding="{Binding Key}"
                IsPullToRefreshEnabled="True"
                RefreshCommand="{Binding LoadDocumentsCommand}"
                IsRefreshing="{Binding IsBusy, Mode=OneWay}">
        <x:Arguments>
            <ListViewCachingStrategy>RecycleElement</ListViewCachingStrategy>
        </x:Arguments>
        <ListView.GroupHeaderTemplate>
          <DataTemplate>
