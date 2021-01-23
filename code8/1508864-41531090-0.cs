    <ListView>
      <ListView.ItemTemplate>
        <DataTemplate>      
            <ViewCell>
                <RelativeLayout>
                    <RelativeLayout IsVisible="{Binding Type, Converter={StaticResource converter1}}"></RelativeLayout>
                    <RelativeLayout IsVisible="{Binding Type, Converter={StaticResource converter2}}"></RelativeLayout>
                </RelativeLayout>
            </ViewCell>
        </DataTemplate>
      </ListView.ItemTemplate>
    </ListView>
