    <ListView.View>
      <GridView>
        <GridView.Columns>
          <GridViewColumn Width="Auto" Header="{Binding NameHeader}" DisplayMemberBinding="{Binding Name}">
            <GridViewColumn.CellTemplate>
              <DataTemplate>
                <Label Grid.Column="0" Content="{Binding Name}" HorizontalAlignment="Left"/>
              </DataTemplate>
            </GridViewColumn.CellTemplate>
          </GridViewColumn>
          <!-- more columns -->
        </GridView.Columns>
      </GridView>
    </ListView.View>
