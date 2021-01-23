    <ItemsControl ItemsSource="{Binding VehicleCollection}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Grid>
               <TextBlock  Visibility="{Binding IsSelected,Converter={StaticResource boolToVisConverter}}"/>
               <TextBlock   Visibility="{Binding IsSelected,Converter={StaticResource boolToVisConverter}}"/>
               <TextBlock   Visibility="{Binding IsSelected,Converter={StaticResource boolToVisConverter}}"/>
            </Grid>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
    <ItemsControl ItemsSource="{Binding VehicleCollection}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Grid>
               <CheckBox Content="{Binding Name}"
                          IsChecked="{Binding IsSelected}" />
            </Grid>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
