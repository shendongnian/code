      <MasterDetailPage.Master>
        <ContentPage Title="Content Page">
          <ContentPage.Content>
            <ListView x:Name="listview" ItemSelected="Listview_itemSelected">
              <ListView.ItemTemplate>
                <DataTemplate>
                  <TextCell Text="{Binding Name}" Detail="{Binding Status}"></TextCell>
                </DataTemplate>
              </ListView.ItemTemplate>
            </ListView>
          </ContentPage.Content>
        </ContentPage>
      </MasterDetailPage.Master>
