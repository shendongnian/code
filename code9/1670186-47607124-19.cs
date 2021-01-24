    <ListView ItemsSource="{Binding Path=YourData}">
        <ListView.View>
             <GridView>
                 <GridViewColumn Header="ID" Width="Auto" 
                      DisplayMemberBinding="{Binding ID}" >
                 </GridViewColumn>
                 <GridViewColumn DisplayMemberBinding="{Binding Name}" 
                      Header="Name" Width="100"/>
                 <GridViewColumn DisplayMemberBinding="{Binding Price}" 
                      Header="Price" Width="100"/>
                 <GridViewColumn DisplayMemberBinding="{Binding Author}" 
                      Header="Author" Width="100"/>
                 <GridViewColumn DisplayMemberBinding="{Binding Catalog}" 
                      Header="Catalog" Width="100"/>
                 <GridViewColumn>
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                          <Button Content="Search"  Command={Binding SearchCommand}  CommandParameter="{Binding Id}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                 </GridViewColumn>
               </GridView>
        </ListView.View>
    </ListView>
