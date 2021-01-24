    private void PopulateListView()
    {
        var l = GetPeople();
        txtJson.Text = JsonConvert.SerializeObject(l);
        LvIssues.ItemsSource= l;
    }
    <ListView x:Name="LvIssues">
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Width="Auto" Header="Id"  DisplayMemberBinding="{Binding Id}"></GridViewColumn>
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView>
