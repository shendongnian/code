    <ListView  ItemsSource="{Binding}" 
            IsGroupingEnabled="true" GroupDisplayBinding="{ Binding Name }"
            GroupShortNameBinding ="{ Binding ShortName }">
        <ListView.GroupHeaderTemplate>
            <DataTemplate>
                <ViewCell Height="25">
                    <StackLayout VerticalOptions="FillAndExpand" Padding="5" 
                         BackgroundColor="#0477B3">
                        <Label Text="{Binding Name}" VerticalOptions="Center"/>
                    </StackLayout>
                </ViewCell>
            </DataTemplate>
        </ListView.GroupHeaderTemplate>
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{ Binding Title }" Detail="{ Binding Description }" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
