                    <Label Grid.Row="0" Name="lblOwnerName" 
                           Content="{Binding OwnerName}">
                    </Label>
                </Grid>
            </GroupBox>
            <ItemsControl Grid.Row="1"
                          ItemsSource="{Binding ContactList}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <local:UCPerson />
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
