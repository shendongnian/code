    **list.xalm**
        <ListView x:Name="listV1" HorizontalAlignment="Left" 
                      Height="263" Margin="44,159,0,0" VerticalAlignment="Top" 
                      Width="283" BorderThickness="0" FontFamily="NanumSquareOTF"
                      FontSize="18"
                      SelectionMode="Single"
                         SelectionChanged="listV1_SelectionChanged"
                         >
                    <ListView.View >
                        <GridView ColumnHeaderContainerStyle="{StaticResource myHeaderStyle}">
                            <GridViewColumn Header="Title" DisplayMemberBinding="{Binding TITLE}" Width="250" />
                        </GridView>
                    </ListView.View>
                </ListView>
    
    **list.xaml.cs**
        private void listV1_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
    
                    var item = listV1.SelectedItem;
                    if (item != null)
                    {
                        uid_tmp = "";
                        DbData selectedItem = (DbData)item;
                        db_tmp = selectedItem.Db;
                        Get_UIDDataAsync();
    
                    }
                }
