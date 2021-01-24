        <Grid Margin="10">
          <Grid.Resources>
                <DataTemplate DataType="{x:Type local:TabOne}">
                   <local:UserControlOne/>
                </DataTemplate>
                <DataTemplate DataType="{x:Type local:TabTwo}">
                   <local:UserControlTwo/>
                </DataTemplate>
          </Grid.Resources>
          <TabControl Margin="10" 
             ItemsSource="{Binding TabViewModels}">
          </TabControl>
       </Grid>
