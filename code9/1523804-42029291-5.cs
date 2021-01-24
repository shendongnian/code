    <ListBox.ItemTemplate>
         <DataTemplate>
              <Grid Grid.IsSharedSizeScope="True">
                  <Grid.ColumnDefinitions>
                       <ColumnDefinition SharedSizeGroup="A"/>
                       <ColumnDefinition SharedSizeGroup="B"/>
                       <ColumnDefinition SharedSizeGroup="C"/>
                  </Grid.ColumnDefinitions>
                  <CheckBox Grid.Column="0"/>
                  <TextBlock Grid.Column="1"/>
                  <TextBlock Grid.Column="2"/>
              </Grid>
          </DataTemplate>
    </ListBox.ItemTemplate>
