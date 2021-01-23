    <MasterDetailPage.Master>
        <ContentPage Title="Content Page">
            <ListView x:Name="listview" ItemSelected="Listview_itemSelected">
              <ListView.ItemTemplate>
                <DataTemplate>
                  <TextCell Text="{Binding Name}" Detail="{Binding Status}"></TextCell>
                </DataTemplate>
              </ListView.ItemTemplate>
            </ListView>
        </ContentPage>
      </MasterDetailPage.Master>
